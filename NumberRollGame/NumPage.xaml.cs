using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace NumberRollGame
{
    public sealed partial class NumPage : UserControl
    {
        private const int NumA = 10;
        public Image[] Nums = new Image[NumA];

        public NumPage()
        {
            this.InitializeComponent();
            CreateFaceArray();
        }

        private void CreateFaceArray()
        {
            Nums[0] = Num1;
            Nums[1] = Num2;
            Nums[2] = Num3;
            Nums[3] = Num4;
            Nums[4] = Num5;
            Nums[5] = Num6;
            Nums[6] = Num7;
            Nums[7] = Num8;
            Nums[8] = Num9;
            Nums[9] = Num10;
        }

        public void DisplayFace(int NumID)
        {
            NumID = NumID - 1;

            for (int i = 0; i < NumA; i++)
            {
                if (i == NumID)
                {
                    Nums[i].Visibility = Visibility.Visible;
                }
                else
                {
                    Nums[i].Visibility = Visibility.Collapsed;
                }
            }
        }
        public void DisplayQ()
        {
            Num1.Visibility = Visibility.Collapsed;
            Num2.Visibility = Visibility.Collapsed;
            Num3.Visibility = Visibility.Collapsed;
            Num4.Visibility = Visibility.Collapsed;
            Num5.Visibility = Visibility.Collapsed;
            Num6.Visibility = Visibility.Collapsed;
            Num7.Visibility = Visibility.Collapsed;
            Num8.Visibility = Visibility.Collapsed;
            Num9.Visibility = Visibility.Collapsed;
            Num10.Visibility = Visibility.Collapsed;
            Q.Visibility = Visibility.Visible;
        }
    }
}
