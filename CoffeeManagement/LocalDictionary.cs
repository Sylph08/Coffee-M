using CoffeeManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CoffeeManagement
{
    public static class LocalDictionary
    {
        public static Dictionary<string, List<Product>> ProductMap = new Dictionary<string, List<Product>>();
        public static Dictionary<string, Product> SmallProductMap = new Dictionary<string, Product>();        
        public static void AddItemToSmallProductMap(string key, Product value)
        {
            if (SmallProductMap.ContainsKey(key))
            {
                SmallProductMap.Remove(key);
                SmallProductMap.Add(key, value);
            }
            else SmallProductMap.Add(key, value);
        }
        public static void AddItemToProductMap(string key, List<Product> value)
        {
            if (ProductMap.ContainsKey(key))
            {
                ProductMap.Remove(key);
                ProductMap.Add(key, value);
            }
            else ProductMap.Add(key, value);
        }

        public static Dictionary<string, List<Employee>> EmployeeMap = new Dictionary<string, List<Employee>>();
        public static Dictionary<string, Employee> SmallEmployeeMap = new Dictionary<string, Employee>();
        public static void AddItemToSmallEmployeeMap(string key, Employee value)
        {
            if (SmallEmployeeMap.ContainsKey(key))
            {
                SmallEmployeeMap.Remove(key);
                SmallEmployeeMap.Add(key, value);
            }
            else SmallEmployeeMap.Add(key, value);
        }
        public static void AddItemToEmployeeMap(string key, List<Employee> value)
        {
            if (EmployeeMap.ContainsKey(key))
            {
                EmployeeMap.Remove(key);
                EmployeeMap.Add(key, value);
            }
            else EmployeeMap.Add(key, value);
        }

        public static Dictionary<string, List<ProductApplyForPromotion>> ProductForPromotionMap = new Dictionary<string, List<ProductApplyForPromotion>>();
        public static void AddToProductPromotionMap(string key, List<ProductApplyForPromotion> value)
        {
            if (ProductForPromotionMap.ContainsKey(key))
            {
                ProductForPromotionMap.Remove(key);
                ProductForPromotionMap.Add(key, value);
            }
            else ProductForPromotionMap.Add(key, value);
        }
        //-----------------------------------------------
        public static Dictionary<string, double> ListDoubles = new Dictionary<string, double>();
        public static void AddToListDoubles(string key, double value)
        {
            if (ListDoubles.ContainsKey(key))
            {
                ListDoubles.Remove(key);
                ListDoubles.Add(key, value);
            }
            else ListDoubles.Add(key, value);
        }
        //---------------------------------------
        public static Dictionary<string, List<BillInfo>> BillInfoMap = new Dictionary<string, List<BillInfo>>();
        public static void AddItemToBillInfoMap(string key, List<BillInfo> value)
        {
            if (BillInfoMap.ContainsKey(key))
            {
                BillInfoMap.Remove(key);
                BillInfoMap.Add(key, value);
            }
            else BillInfoMap.Add(key, value);
        }
        public static Dictionary<string, BillInfo> SmallBillInfoMap = new Dictionary<string, BillInfo>();
        public static void AddItemToSmallBillInfoMap(string key, BillInfo value)
        {
            if (SmallBillInfoMap.ContainsKey(key))
            {
                SmallBillInfoMap.Remove(key);
                SmallBillInfoMap.Add(key, value);
            }
            else SmallBillInfoMap.Add(key, value);
        }
        //---------------------------------------------
        public static Dictionary<string, bool> ListBools = new Dictionary<string, bool>();
        public static void AddToListBools(string key, bool value)
        {
            if (ListBools.ContainsKey(key))
            {
                ListBools.Remove(key);
                ListBools.Add(key, value);
            }
            else ListBools.Add(key, value);
        }
        //----------------------------------------
        public static Dictionary<string, string> ListString = new Dictionary<string, string>();
        public static void AddToListString(string key, string value)
        {
            if (ListString.ContainsKey(key))
            {
                ListString.Remove(key);
                ListString.Add(key, value);
            }
            else ListString.Add(key, value);
        }
        #region Re-use Methods
        public static bool CheckIsDoubleType(string str)
        {
            if (String.IsNullOrEmpty(str)) return true;
            int s;
            s = str.Where(x => x == '.').Count();
            if (s > 1) return false;
            foreach (var i in str)
            {
                if (Int32.TryParse(i.ToString(), out s) == false && i != '.') return false;
            }
            return true;
        }        
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static BitmapImage Base64ToImage(string bgImage64)
        {
            byte[] binaryData = Convert.FromBase64String(bgImage64);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();
            return bi;
        }
        #endregion
    }
}
