﻿using AdvanceTask_NUnit.Global;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;
using NUnit.Framework.Interfaces;

namespace AdvanceTask_NUnit.Pages
{
    public class Certifications : Base
    {
        public Certifications()
        {
            ExcelUtil.PopulateInCollection(excelPath, "Certifications");
        }

        IWebElement certificationTab => driver.FindElement(By.XPath("//a[contains(text(),'Certifications')]"));
        IWebElement certAddNewButton => driver.FindElement(By.XPath("//div[@data-tab='fourth']/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        IWebElement certificateTextbox => driver.FindElement(By.Name("certificationName"));
        IWebElement certificatefromTextbox => driver.FindElement(By.Name("certificationFrom"));
        IWebElement certificateAddButton => driver.FindElement(By.XPath("//input [@type ='button' and @value='Add']"));
        IWebElement certificateText => driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]/div/div/div/table/tbody[last()]/tr/td[1]"));
        IWebElement certificateFromText => driver.FindElement(By.XPath("//div[@class ='form-wrapper']/table/ tbody[last()]/tr/td[2]"));
        IWebElement certificateYearText => driver.FindElement(By.XPath("//div[@class ='form-wrapper']/table/ tbody[last()]/tr/td[3]"));
        IWebElement editCertificateIcon => driver.FindElement(By.XPath("//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]"));
        IWebElement editCertificate => driver.FindElement(By.Name("certificationName"));
        IWebElement editCertificateFrom => driver.FindElement(By.Name("certificationFrom"));
        IWebElement certificateUpdateButton => driver.FindElement(By.XPath("//input[@type='button' and @value='Update']"));
        IWebElement newUpdatedCertificate => driver.FindElement(By.XPath("//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]"));
        IWebElement deleteCertificateIcon => driver.FindElement(By.XPath("//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i"));
        IWebElement deletedCertificateText => driver.FindElement(By.XPath("//div[@class='form-wrapper']/table/tbody[last()]/tr[1]/td[1]"));
        IWebElement msgError1 => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        IWebElement certCancelButton => driver.FindElement(By.XPath("//input[@type='button' and @value='Cancel']"));
        IWebElement certCancelButtonForAdd => driver.FindElement(By.XPath("//input [@type ='button' and @value='Cancel']"));

        //Add Certification            

        public void ClickCertificationTab()
        {

            certificationTab.Click();
        }

        public void CertificationSteps()
        {

            certAddNewButton.Click();

            certificateTextbox.SendKeys(ExcelUtil.ReadData(2, "Certificate"));
            certificatefromTextbox.SendKeys(ExcelUtil.ReadData(2, "From"));
            SelectElement Certificateyear = new SelectElement(driver.FindElement(By.Name("certificationYear")));
            Certificateyear.SelectByValue(ExcelUtil.ReadData(2, "Year"));
        }
        public void CertificationAdd()
        {
            certificateAddButton.Click();
            Thread.Sleep(3000);

        }

        public string GetCertificateFromExcel()
        {
            string certificateFromExcel = (ExcelUtil.ReadData(2, "Certificate"));
            return certificateFromExcel;

        }
        public string GetCertificate()
        {
            return certificateText.Text;

        }


        //Update Certificate Record
        public void UpdateCertificationSteps()
        {
            //certificationTab.Click();
            Wait_Helpers.WaitToBeVisible(driver, "XPath", "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]", 10);
            editCertificateIcon.Click();
            editCertificate.Clear();
            editCertificate.SendKeys(ExcelUtil.ReadData(3, "Certificate"));
            editCertificateFrom.Clear();
            editCertificateFrom.SendKeys(ExcelUtil.ReadData(3, "From"));
            SelectElement editCertificateYear = new SelectElement(driver.FindElement(By.Name("certificationYear")));
            editCertificateYear.SelectByValue(ExcelUtil.ReadData(3, "Year"));
        }
        public void CertificationUpdate()
        {
            certificateUpdateButton.Click();
            Wait_Helpers.WaitToBeVisible(driver, "XPath", "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]", 10);

        }

        public string GetUpdatedCertificate()
        {
            Thread.Sleep(5000);
            return newUpdatedCertificate.Text;
        }

        public string GetUpdatedCertificateFromExcel()
        {
            string certificateUpdatedFromExcel = ExcelUtil.ReadData(3, "Certificate");
            return certificateUpdatedFromExcel;

        }



        //Delete Certificate Record
        public void DeleteCertificate()
        {
            //certificationTab.Click();
            Wait_Helpers.WaitToExist(driver, "XPath", "//div[@class='form-wrapper']/table/ tbody/tr/td[1]", 10);
            deleteCertificateIcon.Click();
            Thread.Sleep(5000);
        }

        public string GetDeleteCertificate()
        {

            return deletedCertificateText.Text;

        }

        //Duplicate record

        public string Duplicate()
        {
            
            certAddNewButton.Click();
            certificateTextbox.SendKeys(ExcelUtil.ReadData(2, "Certificate"));
            certificatefromTextbox.SendKeys(ExcelUtil.ReadData(2, "From"));
            SelectElement Certificateyear = new SelectElement(driver.FindElement(By.Name("certificationYear")));
            Certificateyear.SelectByValue(ExcelUtil.ReadData(2, "Year"));
            certificateAddButton.Click();
            Thread.Sleep(3000);
            certCancelButtonForAdd.Click();
            return msgError1.Text;
            

        }

        //Negative Test cases

        public string NegativeTestNoCert()
        {
            
            Thread.Sleep(5000);
            certAddNewButton.Click();
            certificatefromTextbox.SendKeys(ExcelUtil.ReadData(3, "From"));
            SelectElement Certificateyear = new SelectElement(driver.FindElement(By.Name("certificationYear")));
            Certificateyear.SelectByValue(ExcelUtil.ReadData(3, "Year"));
            certificateAddButton.Click();
            Thread.Sleep(3000);
            certCancelButtonForAdd.Click();
            return msgError1.Text;

        }

        public string NegativeTestNoCertYear()
        {
            //certificationTab.Click();
            
            certAddNewButton.Click();
            certificateTextbox.SendKeys(ExcelUtil.ReadData(3, "Certificate"));
            certificatefromTextbox.SendKeys(ExcelUtil.ReadData(3, "From"));
            certificateAddButton.Click();
            Thread.Sleep(5000);
            certCancelButtonForAdd.Click();
            return msgError1.Text;
        }

        public string NegativeTestNone()
        {
            //certificationTab.Click();
            Thread.Sleep(5000);
            certAddNewButton.Click(); ;
            certificateAddButton.Click();
            Thread.Sleep(5000);
            certCancelButtonForAdd.Click();
            return msgError1.Text;
        }

        //More tests for Update

        public string DuplicateUpdateCertificate()
        {
            Thread.Sleep(3000);
            //certificationTab.Click();
            editCertificateIcon.Click();
            Thread.Sleep(3000);
            certificateUpdateButton.Click();
            
            certCancelButton.Click();
            return msgError1.Text;
        }




    }
}
