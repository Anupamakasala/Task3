using AdvanceTask_NUnit.Global;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceTask_NUnit.Global.GlobalDefinitions;

namespace AdvanceTask_NUnit.Pages
{
    public class Certifications:Base
    {
       public Certifications() 
        {
            ExcelUtil.PopulateInCollection(@"D:\Advanced_Tasks\Task3\AdvanceTask_NUnit\AdvanceTask_NUnit\TestData\TestData.xlsx", "Certifications");
        }

        IWebElement CertificationTab => driver.FindElement(By.XPath("//a[contains(text(),'Certifications')]"));
        IWebElement CertAddnewButton => driver.FindElement(By.XPath("//div[@data-tab='fourth']/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        IWebElement certificateTextbox => driver.FindElement(By.Name("certificationName"));
        IWebElement certificatefromTextbox => driver.FindElement(By.Name("certificationFrom"));
        IWebElement certificateAddButton => driver.FindElement(By.XPath("//input [@type ='button' and @value='Add']"));
        IWebElement CertificateText => driver.FindElement(By.XPath("//div[@data-tab=\"fourth\"]/div/div/div/table/tbody[last()]/tr/td[1]"));
        IWebElement CertificateFromText => driver.FindElement(By.XPath("//div[@class ='form-wrapper']/table/ tbody[last()]/tr/td[2]"));
        IWebElement CertificateYearText => driver.FindElement(By.XPath("//div[@class ='form-wrapper']/table/ tbody[last()]/tr/td[3]"));
        IWebElement EditCertificateIcon => driver.FindElement(By.XPath("//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]"));
        IWebElement EditCertificate => driver.FindElement(By.Name("certificationName"));
        IWebElement EditCertificateFrom => driver.FindElement(By.Name("certificationFrom"));
        IWebElement CertificateUpdateButton => driver.FindElement(By.XPath("//input[@type='button' and @value='Update']"));
        IWebElement NewUpdatedCertificate => driver.FindElement(By.XPath("//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]"));
        IWebElement DeleteCertificateIcon => driver.FindElement(By.XPath("//div[@data-tab='fourth']/div/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]/i"));
        IWebElement DeletedCertificateText => driver.FindElement(By.XPath("//div[@class='form-wrapper']/table/tbody[last()]/tr[1]/td[1]"));

        //Add Certification            

        public void ClickCertificationTab()
        {
            CertificationTab.Click();
        }

        public void CertificationSteps()
        {

            CertAddnewButton.Click();

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
            string CertificateFromExcel = (ExcelUtil.ReadData(2, "Certificate"));
            return CertificateFromExcel;

        }
        public string GetCertificate()
        {
            return CertificateText.Text;

        }


        //Update Certificate Record
        public void UpdateCertificationSteps()
        {
            //CertificationTab.Click();
            Wait_Helpers.WaitToBeVisible(driver, "XPath", "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]", 10);
            EditCertificateIcon.Click();
            EditCertificate.Clear();
            EditCertificate.SendKeys(ExcelUtil.ReadData(3, "Certificate"));
            EditCertificateFrom.Clear();
            EditCertificateFrom.SendKeys(ExcelUtil.ReadData(3, "From"));
            SelectElement EditCertificateyear = new SelectElement(driver.FindElement(By.Name("certificationYear")));
            EditCertificateyear.SelectByValue(ExcelUtil.ReadData(3, "Year"));
        }
            public void CertificationUpdate()
            { 
            CertificateUpdateButton.Click();
            Wait_Helpers.WaitToBeVisible(driver, "XPath", "//div[@data-tab='fourth']/div/div/div/table/tbody[last()]/tr/td[1]", 10);
                       
           }

        public string GetUpdatedCertificate()
        {
            Thread.Sleep(5000);
            return NewUpdatedCertificate.Text;
        }

        public string GetUpdatedCertificateFromExcel()
        {
            string CertificateUpdatedFromExcel = ExcelUtil.ReadData(3, "Certificate");
            return CertificateUpdatedFromExcel;

        }



        //Delete Certificate Record
        public void DeleteCertificate()
        {
            CertificationTab.Click();
            Wait_Helpers.WaiToExist(driver, "XPath", "//div[@class='form-wrapper']/table/ tbody/tr/td[1]", 10);
            DeleteCertificateIcon.Click();
            Thread.Sleep(5000);
        }

        public string GetDeleteCertificate()
        {

            return DeletedCertificateText.Text;

        }



    }
}
