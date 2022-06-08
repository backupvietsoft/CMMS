using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eAquaServer
{
    public class eAquaParameter
    {
        public struct Customer
        {
            public string cmdQuery;
            public string ID;
            public string Name;
            public string Address;
            public string Manager;
            public string HandPhone;
            public string Province;
            public string Email;
            public string Password;
            public string AutoRefresh;
            public string Alarm;
            public string TimeRefresh;
            public void ProcessDataFromClient(string[] _msgString_)
            {
                cmdQuery = "";
                ID = "";
                Name = "";
                Address = "";
                Manager = "";
                HandPhone = "";
                Province = "";
                Email = "";
                Password = "";
                AutoRefresh = "";
                Alarm = "";
                TimeRefresh = "";
                string[] temp_split_string;
                temp_split_string = _msgString_;
                //reset cac thong so cua bang
                
                //load tat ca cac cuoi cat ra de lay du lieu
                for (int i = temp_split_string.Length - 1; i >= 0; i--)
                {
                    string _temp;
                    _temp = temp_split_string[i];
                    if (_temp == "ID")
                    {
                        ID = (temp_split_string[i + 1]);
                    }
                    else if (_temp == "Name")
                    {
                        Name = (temp_split_string[i + 1]);
                    }
                    else if (_temp == "Address")
                    {
                        Address = temp_split_string[i + 1];
                    }
                    else if (_temp == "Manager")
                    {
                        Manager = temp_split_string[i + 1];
                    }
                    else if (_temp == "HandPhone")
                    {
                        HandPhone = temp_split_string[i + 1];
                    }
                    else if (_temp == "Province")
                    {
                        Province = temp_split_string[i + 1];
                    }
                    else if (_temp == "cmdQuery")
                    {
                        cmdQuery = temp_split_string[i + 1];
                    }
                    else if (_temp == "Email")
                    {
                        Email = temp_split_string[i + 1];
                    }
                    else if (_temp == "Password")
                    {
                        Password = temp_split_string[i + 1];
                    }
                    else if (_temp == "AutoRefresh")
                    {
                        AutoRefresh = temp_split_string[i + 1];
                    }
                    else if (_temp == "Alarm")
                    {
                        Alarm = temp_split_string[i + 1];
                    }
                    else if (_temp == "TimeRefresh")
                    {
                        TimeRefresh = temp_split_string[i + 1];
                    }
                }
            }
        }
        public struct MeasuringSystem
        {
            public string cmdQuery;
            public string ID;
            public string Name;
            public string Note;
            public string CustomerID;
            public string PhoneNo;
            public string Cycle;
            public string IpPLC;
            public void ProcessDataFromClient(string[] _msgString_)
            {
                IpPLC = "";
                cmdQuery = "";
                ID = "";
                Name = "";
                Note = "";
                CustomerID = "";
                PhoneNo = "";
                Cycle = "";
                string[] temp_split_string;
                temp_split_string = _msgString_;
                //reset cac thong so cua bang

                //load tat ca cac cuoi cat ra de lay du lieu
                for (int i = temp_split_string.Length - 1; i >= 0; i--)
                {
                    string _temp;
                    _temp = temp_split_string[i];
                    if (_temp == "ID")
                    {
                        ID = (temp_split_string[i + 1]);
                    }
                    else if (_temp == "Name")
                    {
                        Name = temp_split_string[i + 1];
                    }
                    else if (_temp == "Note")
                    {
                        Note = temp_split_string[i + 1];
                    }
                    else if (_temp == "CustomerID")
                    {
                        CustomerID = temp_split_string[i + 1];
                    }
                    else if (_temp == "PhoneNo")
                    {
                        PhoneNo = temp_split_string[i + 1];
                    }
                    else if (_temp == "Cycle")
                    {
                        Cycle = temp_split_string[i + 1];
                    }
                    else if (_temp == "cmdQuery")
                    {
                        cmdQuery = temp_split_string[i + 1];
                    }
                    else if (_temp == "IP")
                    {
                        IpPLC = temp_split_string[i + 1];
                    }
                }
            }
        }
        public struct MeasuringHead
        {
            public string cmdQuery;
            public string ID;
            public string Name;
            public string Description;
            public string SystemID;
            public void ProcessDataFromClient(string[] _msgString_)
            {
                cmdQuery = "";
                ID = "";
                Name = "";
                Description = "";
                SystemID = "";
                string[] temp_split_string;
                temp_split_string = _msgString_;
                //reset cac thong so cua bang

                //load tat ca cac cuoi cat ra de lay du lieu
                for (int i = temp_split_string.Length - 1; i >= 0; i--)
                {
                    string _temp;
                    _temp = temp_split_string[i];
                    if (_temp == "ID")
                    {
                        ID = (temp_split_string[i + 1]);
                    }
                    else if (_temp == "Name")
                    {
                        Name = temp_split_string[i + 1];
                    }
                    else if (_temp == "Description")
                    {
                        Description = temp_split_string[i + 1];
                    }
                    else if (_temp == "SystemID")
                    {
                        SystemID = temp_split_string[i + 1];
                    }
                    else if (_temp == "cmdQuery")
                    {
                        cmdQuery = temp_split_string[i + 1];
                    }
                }
            }
        }
        public struct Ponds
        {
            public string cmdQuery;
            public string ID;
            public string Name;
            public string Description;
            public string CustomerID;
            public string UpperTemp;
            public string LowerTemp;
            public string UpperPH;
            public string LowerPH;
            public string UpperDO;
            public string LowerDO;
            public string UpperNH3;
            public string LowerNH3;
            public string UpperNO2;
            public string LowerNO2;
            public string UpperSalinity;
            public string LowerSalinity;
            public void ProcessDataFromClient(string[] _msgString_)
            {
                cmdQuery = "";
                ID = "";
                Name = "";
                Description = "";
                CustomerID = "";
                UpperTemp = "NULL";
                LowerTemp = "NULL";
                UpperPH = "NULL";
                LowerPH = "NULL";
                UpperDO = "NULL";
                LowerDO = "NULL";
                UpperNH3 = "NULL";
                LowerNH3 = "NULL";
                UpperNO2 = "NULL";
                LowerNO2 = "NULL";
                UpperSalinity = "NULL";
                LowerSalinity = "NULL";
                string[] temp_split_string;
                temp_split_string = _msgString_;
                //reset cac thong so cua bang

                //load tat ca cac cuoi cat ra de lay du lieu
                for (int i = temp_split_string.Length - 1; i >= 0; i--)
                {
                    string _temp;
                    _temp = temp_split_string[i];
                    if (_temp == "ID")
                    {
                        ID = (temp_split_string[i + 1]);
                    }
                    else if (_temp == "Name")
                    {
                        Name = temp_split_string[i + 1];
                    }
                    else if (_temp == "Description")
                    {
                        Description = temp_split_string[i + 1];
                    }
                    else if (_temp == "CustomerID")
                    {
                        CustomerID = temp_split_string[i + 1];
                    }
                    else if (_temp == "cmdQuery")
                    {
                        cmdQuery = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperTemp")
                    {
                        UpperTemp = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerTemp")
                    {
                        LowerTemp = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperPH")
                    {
                        UpperPH = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerPH")
                    {
                        LowerPH = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperDO")
                    {
                        UpperDO = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerDO")
                    {
                        LowerDO = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperNH3")
                    {
                        UpperNH3 = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerNH3")
                    {
                        LowerNH3 = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperNO2")
                    {
                        UpperNO2 = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerNO2")
                    {
                        LowerNO2 = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperSalinity")
                    {
                        UpperSalinity = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerSalinity")
                    {
                        LowerSalinity = temp_split_string[i + 1];
                    }
                }
            }
        }
        public struct MeasurementPoint
        {
            public string cmdQuery;
            public string ID;
            public string Name;
            public string Description;
            public string UpperTemp;
            public string LowerTemp;
            public string UpperPH;
            public string LowerPH;
            public string UpperDO;
            public string LowerDO;
            public string UpperNH3;
            public string LowerNH3;
            public string UpperNO2;
            public string LowerNO2;
            public string UpperSalinity;
            public string LowerSalinity;
            public string PondsID;
            public string MesuringHeadID;
            public void ProcessDataFromClient(string[] _msgString_)
            {
                cmdQuery = "";
                ID = "";
                Name = "";
                Description = "";
                UpperTemp = "NULL";
                LowerTemp = "NULL";
                UpperPH = "NULL";
                LowerPH = "NULL";
                UpperDO = "NULL";
                LowerDO = "NULL";
                UpperNH3 = "NULL";
                LowerNH3 = "NULL";
                UpperNO2 = "NULL";
                LowerNO2 = "NULL";
                UpperSalinity = "NULL";
                LowerSalinity = "NULL";
                PondsID = "";
                MesuringHeadID = "";
                string[] temp_split_string;
                temp_split_string = _msgString_;
                //reset cac thong so cua bang

                //load tat ca cac cuoi cat ra de lay du lieu
                for (int i = temp_split_string.Length - 1; i >= 0; i--)
                {
                    string _temp;
                    _temp = temp_split_string[i];
                    if (_temp == "ID")
                    {
                        ID = (temp_split_string[i + 1]);
                    }
                    else if (_temp == "Name")
                    {
                        Name = temp_split_string[i + 1];
                    }
                    else if (_temp == "Description")
                    {
                        Description = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperTemp")
                    {
                        UpperTemp = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerTemp")
                    {
                        LowerTemp = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperPH")
                    {
                        UpperPH = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerPH")
                    {
                        LowerPH = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperDO")
                    {
                        UpperDO = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerDO")
                    {
                        LowerDO = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperNH3")
                    {
                        UpperNH3 = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerNH3")
                    {
                        LowerNH3 = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperNO2")
                    {
                        UpperNO2 = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerNO2")
                    {
                        LowerNO2 = temp_split_string[i + 1];
                    }
                    else if (_temp == "UpperSalinity")
                    {
                        UpperSalinity = temp_split_string[i + 1];
                    }
                    else if (_temp == "LowerSalinity")
                    {
                        LowerSalinity = temp_split_string[i + 1];
                    }
                    else if (_temp == "PondsID")
                    {
                        PondsID = temp_split_string[i + 1];
                    }
                    else if (_temp == "MesuringHeadID")
                    {
                        MesuringHeadID = temp_split_string[i + 1];
                    }
                    else if (_temp == "cmdQuery")
                    {
                        cmdQuery = temp_split_string[i + 1];
                    }
                }
            }
        }
        public struct MeasurementResults
        {
            public string cmdQuery;
            public string ID;
            public string MeasuringTime;
            public string TempValue;
            public string pHValue;
            public string DOValue;
            public string NH3Value;
            public string NO2Value;
            public string SalinityValue;
            public string MeasurementPointID;
            public string MeasurementHeadID;
            public string IpClient;
            public string Error;
            public string Q11;
            public string Q12;
            public string Q13;
            public string Q14;
            public string Q21;
            public string Q22;
            public string Q23;
            public string Q24;
            public string QP1;
            public string QP2;
            public string QFS1;
            public string QFS2;
            public string QFB1;
            public string QFB2;
            public void ProcessDataFromClient(string[] _msgString_)
            {
                IpClient = "";
                cmdQuery = "";
                ID = "";
                MeasuringTime = "";
                TempValue = "";
                pHValue = "NULL";
                DOValue = "NULL";
                NH3Value = "NULL";
                NO2Value = "NULL";
                SalinityValue = "NULL";
                MeasurementPointID = "";
                MeasurementHeadID = "";
                Q11 = "NULL";
                Q12 = "NULL";
                Q13 = "NULL";
                Q14 = "NULL";
                Q21 = "NULL";
                Q22 = "NULL";
                Q23 = "NULL";
                Q24 = "NULL";
                QP1 = "NULL";
                QP2 = "NULL";
                QFS1 = "NULL";
                QFS2 = "NULL";
                QFB1 = "NULL";
                QFB2 = "NULL";
                string[] temp_split_string;
                temp_split_string = _msgString_;
                //reset cac thong so cua bang

                try{
                //load tat ca cac cuoi cat ra de lay du lieu
                for (int i = temp_split_string.Length - 1; i >= 0; i--)
                {
                    string _temp;
                    _temp = temp_split_string[i];
                    if (_temp == "ID")
                    {
                        ID = (temp_split_string[i + 1]);
                    }
                    else if (_temp == "MeasuringTime")
                    {
                        MeasuringTime = temp_split_string[i + 1];
                    }
                    else if (_temp == "TempValue")
                    {
                        TempValue = temp_split_string[i + 1];
                        if (float.Parse(TempValue) <= 0 || float.Parse(TempValue) >= 40) { TempValue = "0"; }
                        
                        
                    }
                    else if (_temp == "pHValue")
                    {
                        pHValue = temp_split_string[i + 1];
                        if (float.Parse(pHValue) <= 0 || float.Parse(pHValue) >= 15) { pHValue = "0";  }


                    }
                    else if (_temp == "DOValue")
                    {
                        DOValue = temp_split_string[i + 1];
                        if (float.Parse(DOValue) <= 0 || float.Parse(DOValue) >= 15) { DOValue = "0";}


                    }
                    else if (_temp == "NH3Value")
                    {
                        NH3Value = temp_split_string[i + 1];
                        if (float.Parse(NH3Value) <= 0 || float.Parse(NH3Value) >= 15) { NH3Value = "0"; }


                    }
                    else if (_temp == "NO2Value")
                    {
                        NO2Value = temp_split_string[i + 1];
                        if (float.Parse(NO2Value) <= 0 || float.Parse(NO2Value) >= 15) { NO2Value = "0";}


                    }
                    else if (_temp == "SalinityValue")
                    {
                        SalinityValue = temp_split_string[i + 1];
                        if (float.Parse(SalinityValue) <= 0 || float.Parse(SalinityValue) >= 50) { SalinityValue = "0"; }


                    }
                    else if (_temp == "MeasurementPointID")
                    {
                        MeasurementPointID = temp_split_string[i + 1];
                    }
                    else if (_temp == "MeasurementHeadID")
                    {
                        MeasurementHeadID = temp_split_string[i + 1];
                    }
                    else if (_temp == "cmdQuery")
                    {
                        cmdQuery = temp_split_string[i + 1];
                    }
                    else if (_temp == "IP")
                    {
                        IpClient = temp_split_string[i + 1];
                    }
                    else if (_temp == "Error")
                    {
                        Error = temp_split_string[i + 1];
                    }
                    else if (_temp == "Q11")
                    {
                        Q11 = temp_split_string[i + 1];
                    }
                    else if (_temp == "Q12")
                    {
                        Q12 = temp_split_string[i + 1];
                    }
                    else if (_temp == "Q13")
                    {
                        Q13 = temp_split_string[i + 1];
                    }
                    else if (_temp == "Q14")
                    {
                        Q14 = temp_split_string[i + 1];
                    }
                    else if (_temp == "Q21")
                    {
                        Q21 = temp_split_string[i + 1];
                    }
                    else if (_temp == "Q22")
                    {
                        Q22 = temp_split_string[i + 1];
                    }
                    else if (_temp == "Q23")
                    {
                        Q23 = temp_split_string[i + 1];
                    }
                    else if (_temp == "Q24")
                    {
                        Q24 = temp_split_string[i + 1];
                    }
                    else if (_temp == "QP1")
                    {
                        QP1 = temp_split_string[i + 1];
                    }
                    else if (_temp == "QP2")
                    {
                        QP2 = temp_split_string[i + 1];
                    }
                    else if (_temp == "QFS1")
                    {
                        QFS1 = temp_split_string[i + 1];
                    }
                    else if (_temp == "QFS2")
                    {
                        QFS2 = temp_split_string[i + 1];
                    }
                    else if (_temp == "QFB1")
                    {
                        QFB1 = temp_split_string[i + 1];
                    }
                    else if (_temp == "QFB2")
                    {
                        QFB2 = temp_split_string[i + 1];
                    }
                }
                    }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                };

            }
        }
    }
}
