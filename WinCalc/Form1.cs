﻿using CalcBase.Models;
using ReactCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalc
{
    public partial class frmMain : Form
    {
        //private 
        private Calc Calc { get; set; }
        private IOperation op { get; set; }
        private IOperation O
        {
            get
            {
                return op;
            }
            set
            {
                op = value;
                DisOperation = value as IDisplayOperation;
            }
        }

        private IDisplayOperation DisOperation { get; set; }
        private DateTime? lastPressTime { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            Calc = new Calc();

            var operations = Calc.Operations;

            lbOperations.DataSource = operations;
            lbOperations.DisplayMember = "Name";
            lbOperations.SelectedIndex = 0;
            lblResult.Text = "";


        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void lbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var displayOper = lbOperations.SelectedItem as IDisplayOperation;
            if (displayOper != null)
            {
                lblDescription.Text = string.Format("Автор: {0}{1}Описание: {2}",
                    displayOper.Author,
                    Environment.NewLine,
                    !string.IsNullOrWhiteSpace(displayOper.Description)
                    ? displayOper.Description
                    : "");
            }
            lastPressTime = DateTime.Now;
            timer1.Start();
        }

        private void tbX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectAction() != "Сложная задача")
                {
                    lastPressTime = DateTime.Now;
                    timer1.Start();
                }
                tbY.Focus();
            }
        }

        private void tbY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectAction() != "Сложная задача")
                {
                    lastPressTime = DateTime.Now;
                    timer1.Start();
                }
                tbX.Focus();
            }
        }

        private void tbX_TextChanged(object sender, EventArgs e)
        {
            if (tbX.Text == "" || SelectAction() == "Сложная задача")
            {
                return;
            }
            lastPressTime = DateTime.Now;
            timer1.Start();

        }

        private void tbY_TextChanged(object sender, EventArgs e)
        {
            if (tbY.Text == "")
            {
                return;
            }
            lastPressTime = DateTime.Now;
            timer1.Start();
        }

        private string SelectAction()
        {
            var oper = lbOperations.SelectedItem as IOperation;


            string type = DisOperation != null
                ? DisOperation.Type
                : "Сложная задача";
            type = type != ""
                ? "Простая задача"
                : "Сложная задача";

            return type;
        }

        private void Calculate()
        {
            // определяем операцию
            var oper = lbOperations.SelectedItem as IOperation;
            if (oper == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }

            // определяем входные данные
            var x = Calc.ToDouble(tbX.Text);
            var y = Calc.ToDouble(tbY.Text);
            try
            {
                // вычисляем 
                var result = Calc.Execute(oper.Execute, new[] { x, y });


                string operName = DisOperation != null
                    ? DisOperation.DisplayName
                    : oper.Name;
                // возвращаем результат
                lblResult.Text = string.Format("{0} = {1} {2}", operName, result, Environment.NewLine);
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Опаньки: {ex.Message}";
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            tbX.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lastPressTime.HasValue)
            {
                var diffTime = DateTime.Now - lastPressTime.Value;

                if (diffTime.TotalMilliseconds >= 200)
                {
                    Calculate();
                    lastPressTime = null;
                    timer1.Stop();
                }
            }
        }
    }
}
