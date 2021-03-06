﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zintcsharp.Symbologies
{
    public partial class QRCode : UserControl, IBarcode
    {
        public event EventHandler OptionsChanged;
        private Symbology symbology;

        public QRCode(Symbology symb)
        {
            InitializeComponent();

            this.symbology = symb;
            this.symbology.Option1 = 0;
            this.symbology.Option2 = 0;
            this.symbology.Option3 = 0;
            this.symbology.InputMode = 0;
        }

        public Symbology GetSymbology()
        {
            return this.symbology;
        }

        public UserControl GetControl()
        {
            return this;
        }

        private void QRCode_Load(object sender, EventArgs e)
        {
            // minimum error correction
            int[] Option1Values = new int[] { 1, 2, 3, 4 };
            String[] Option1 = new String[] { "~20% (Level L)", "~37% (Level H)", "~55% (Level Q)", "~65% (Level H)" };

            // size
            int[] Option2Values = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 };
            String[] Option2 = new String[] { "21 x 21 (Version 1)", "25 x 25 (Version 2)", "29 x 29 (Version 3)", 
                "33 x 33 (Version 4)", "37 x 37 (Version 5)", "41 x 41 (Version 6)", "45 x 45 (Version 7)", "49 x 49 (Version 8)", 
                "53 x 53 (Version 9)", "57 x 57 (Version 10)", "61 x 61 (Version 11)", "65 x 65 (Version 12)", "69 x 69 (Version 13)", 
                "73 x 73 (Version 14)", "77 x 77 (Version 15)", "81 x 81 (Version 16)", "85 x 85 (Version 17)", "89 x 89 (Version 18)", 
                "93 x 93 (Version 19)", "97 x 97 (Version 20)", "101 x 101 (Version 21)", "105 x 105 (Version 22)", "109 x 109 (Version 23)", 
                "113 x 113 (Version 24)", "117 x 117 (Version 25)", "121 x 121 (Version 26)", "125 x 125 (Version 27)", "129 x 129 (Version 28)", 
                "133 x 133 (Version 29)", "137 x 137 (Version 30)", "141 x 141 (Version 31)", "145 x 145 (Version 32)", "149 x 149 (Version 33)", 
                "153 x 153 (Version 34)", "157 x 157 (Version 35)", "161 x 161 (Version 36)", "165 x 165 (Version 37)", "169 x 169 (Version 38)", 
                "173 x 173 (Version 39)", "177 x 177 (Version 40)"};

            option1.PopulateOptions(Option1);
            option2.PopulateOptions(Option2);
            option1.SelectedIndex = 0;
            option2.SelectedIndex = 0;

            // default values
            symbology.Symbol = BarcodeTypes.QRCODE;
            symbology.InputMode = 0;
            symbology.Option1 = 0;
            symbology.Option2 = 0;
            option1.Enabled = false;
            option2.Enabled = false;
        }

        private void optionElement_OptionsChanged(object sender, EventArgs e)
        {
            if (option1Selected.Checked)
            {
                symbology.Option1 = option1.GetSelectedItemValue();
                symbology.Option2 = 0;
                option1.Enabled = true;
                option2.Enabled = false;
            }
            else if (option2Selected.Checked)
            {
                symbology.Option2 = option2.GetSelectedItemValue();
                symbology.Option1 = 0;
                option1.Enabled = false;
                option2.Enabled = true;
            }
            else
            {
                symbology.Option1 = 0;
                symbology.Option2 = 0;
                option1.Enabled = false;
                option2.Enabled = false;
            }
                

            if (this.OptionsChanged != null)
                this.OptionsChanged(new object(), new EventArgs());
        }
        private void encodingRadioButton_OptionsChanged(object sender, EventArgs e)
        {
            if (gs1DataMode.Checked)
            {
                symbology.Symbol = BarcodeTypes.QRCODE;
                symbology.InputMode = 2;
            }
            else if (hibcMode.Checked)
            {
                symbology.Symbol = BarcodeTypes.HIBC_QR;
                symbology.InputMode = 0;
            }
            else
            {
                symbology.Symbol = BarcodeTypes.QRCODE;
                symbology.InputMode = 0;
            }

            if (this.OptionsChanged != null)
                this.OptionsChanged(new object(), new EventArgs());
        }
    }
}
