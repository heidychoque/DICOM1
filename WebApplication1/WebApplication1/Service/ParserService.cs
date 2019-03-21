using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Service
{
   public class ParserService
    {

        public List<Segmento> segmentos1 = new List<Segmento>();
        //public List<Campo> campos = new List<Campo>();
        //public char soydelimitador ='';

       /* public void reader2()
        {
            Campo campo1 = new Campo();
            campo1.data = "hola";
            campo1.isEmpty = true;
            campo1.nombre = "PID";

            campos.Add(campo1);
            Segmento segmentoaux = new Segmento();
            segmentoaux.campos = campos;

            segmentos1.Add(segmentoaux);
            
        }*/
        
         public List<Segmento> reader2()
         {
             string[] lines = System.IO.File.ReadAllLines("C:\\Users\\usuario\\Documents\\Bioinfo\\ejemplo.txt");
             int x = lines.Length;


            // System.Console.WriteLine("Contents of WriteLines2.txt = ");

             char soydelimitador = cualesdelimitador(lines[0]);
             for (int i = 0; i < lines.Length; i++)
             {

                 myparser2(lines[i], soydelimitador);
             }
             //System.Console.ReadKey();

            return segmentos1;

         }


         public void myparser2(string messageline, char esdelimitador)
         {

             string[] parts = messageline.Split(esdelimitador);

             for (int i = 0; i < parts.Length; i++)
             {
                 Console.WriteLine(i + " " + parts[i]);

             }

             quesegmentoes2(parts, esdelimitador);
         }

         public char cualesdelimitador(string message)
         {
             string aux = message.Substring(3);
             char delimitador = aux[0];
             return delimitador;
         }
         public void quesegmentoes2(string[] segmento, char esdelimitador)
         {
             if (string.Equals(segmento[0], "MSH"))
             {
                 Segmento MSH = new Segmento();

                 MSH = soyMSH(segmento, MSH, esdelimitador);
                 
                 /*for (int i = 0; i < MSH.campos.Count; i++)
                 {
                     Console.WriteLine(MSH.campos.ElementAt(i).nombre + ":" + MSH.campos.ElementAt(i).data);
                 }
                 */

               if ((MSH.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true)))&& (MSH.camposobligados.Count == 6))
                {
                    MSH.errorText="Todos los obligados en MSH SI se encuentran en el mensaje";
                 }
                 else { MSH.errorText = "Todos los obligados en MSH NO se encuentran en el mensaje"; }
                segmentos1.Add(MSH);

            }
             
             else if (String.Equals(segmento[0], "NTE"))
             {
                 Segmento NTE = new Segmento();
                 NTE = soyNTE(segmento, NTE);
                 
                 /*for (int i = 0; i < NTE.campos.Capacity; i++)
                 {
                     Console.WriteLine(NTE.campos[i].nombre + ":" + NTE.campos[i].data);
                 }
                 */
                if ((NTE.camposobligados.All(y => !Equals(y.isEmpty, true))))
                {
                    NTE.errorText="Todos los obligados en NTE SI se encuentran en el mensaje";
                 }
                 else { NTE.errorText = "Todos los obligados en NTE NO se encuentran en el mensaje"; }
                segmentos1.Add(NTE);
            }
             
             else if (String.Equals(segmento[0], "PID"))
             {
                 Segmento PID = new Segmento();
                 PID = soyPID(segmento, PID);
                 
                 /*for (int i = 0; i < PID.campos.Capacity; i++)
                 {
                     Console.WriteLine(PID.campos[i].nombre + ":" + PID.campos[i].data);
                 }*/

                if ((PID.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true))) && (PID.camposobligados.Count == 2))
                {
                     PID.errorText="Todos los obligados en PID SI se encuentran en el mensaje";
                 }
                 else { PID.errorText ="Todos los obligados en PID NO se encuentran en el mensaje"; }
                segmentos1.Add(PID);
            }
             
             else if (String.Equals(segmento[0], "PD1"))
             {

                 Segmento PD1 = new Segmento();
                 PD1 = soyPID(segmento, PD1);
                 
                 /*for (int i = 0; i < PD1.campos.Capacity; i++)
                 {
                     Console.WriteLine(PD1.campos[i].nombre + ":" + PD1.campos[i].data);
                 }*/
                if (PD1.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true)))
                {
                     PD1.errorText="Todos los obligados en PD1 SI se encuentran en el mensaje";
                 }
                 else { PD1.errorText = "Todos los obligados en PD1 NO se encuentran en el mensaje"; }
                segmentos1.Add(PD1);

            }
             
             else if (String.Equals(segmento[0], "PV1"))
             {
                 Segmento PV1 = new Segmento();
                 PV1 = soyPV1(segmento, PV1);

                /*for (int i = 0; i < PV1.campos.Capacity; i++)
                {
                    Console.WriteLine(PV1.campos[i].nombre + ":" + PV1.campos[i].data);
                }
                */
                if ((PV1.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true))) && (PV1.camposobligados.Count == 1))
                {
                     PV1.errorText="Todos los obligados en PV1 SI se encuentran en el mensaje";
                 }
                 else { PV1.errorText = "Todos los obligados en PV1 NO se encuentran en el mensaje"; }
                segmentos1.Add(PV1);
            }
             
             else if (String.Equals(segmento[0], "PV2"))
             {
                 Segmento PV2 = new Segmento();
                 PV2 = soyPID(segmento, PV2);
                 
                 /*for (int i = 0; i < PV2.campos.Capacity; i++)
                 {
                     Console.WriteLine(PV2.campos[i].nombre + ":" + PV2.campos[i].data);
                 }*/

                if (PV2.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true)))
                {
                     PV2.errorText="Todos los obligados en PV2 SI se encuentran en el mensaje";
                 }
                 else { PV2.errorText = "Todos los obligados en PV2 NO se encuentran en el mensaje"; }
                segmentos1.Add(PV2);
             }
             
             else if (String.Equals(segmento[0], "IN1"))
             {
                 Segmento IN1 = new Segmento();
                 IN1 = soyIN1(segmento, IN1);

                /*for (int i = 0; i < IN1.campos.Capacity; i++)
                {
                    Console.WriteLine(IN1.campos[i].nombre + ":" + IN1.campos[i].data);
                }
                */
                if ((IN1.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true))) && (IN1.camposobligados.Count == 2))
                {
                     IN1.errorText="Todos los obligados en IN1 SI se encuentran en el mensaje";
                 }
                 else { IN1.errorText = "Todos los obligados en IN1 NO se encuentran en el mensaje"; }
                segmentos1.Add(IN1);
            }
             
             else if (String.Equals(segmento[0], "IN2"))
             {
                 Segmento IN2 = new Segmento();
                 IN2 = soyIN2(segmento, IN2);
                 segmentos1.Add(IN2);
                /* for (int i = 0; i < IN2.campos.Capacity; i++)
                 {
                     Console.WriteLine(IN2.campos[i].nombre + ":" + IN2.campos[i].data);
                 }*/

                if (IN2.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true)))
                {
                     IN2.errorText="Todos los obligados en IN2 SI se encuentran en el mensaje";
                 }
                 else { IN2.errorText = "Todos los obligados en IN2 NO se encuentran en el mensaje"; }
                segmentos1.Add(IN2);
            }
             
             else if (String.Equals(segmento[0], "IN3"))
             {
                 Segmento IN3 = new Segmento();
                 IN3 = soyIN3(segmento, IN3);
                 
                /* for (int i = 0; i < IN3.campos.Capacity; i++)
                 {
                     Console.WriteLine(IN3.campos[i].nombre + ":" + IN3.campos[i].data);
                 }*/

                if (IN3.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true)))
                {
                     IN3.errorText="Todos los obligados en IN3 SI se encuentran en el mensaje";
                 }
                 else { IN3.errorText = "Todos los obligados en IN3 NO se encuentran en el mensaje"; }
                segmentos1.Add(IN3);
            }
             
             else if (String.Equals(segmento[0], "GT1"))
             {
                 Segmento GT1 = new Segmento();
                 GT1 = soyGT1(segmento, GT1);
                 
                /*for (int i = 0; i < GT1.campos.Capacity; i++)
                {
                    Console.WriteLine(GT1.campos[i].nombre + ":" + GT1.campos[i].data);
                }*/

                if ((GT1.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true))) && (GT1.camposobligados.Count == 2))
                {
                     GT1.errorText="Todos los obligados en GT1 SI se encuentran en el mensaje";
                 }
                 else { GT1.errorText = "Todos los obligados en GT1 NO se encuentran en el mensaje"; }
                segmentos1.Add(GT1);
            }
             
             else if (String.Equals(segmento[0], "AL1"))
             {
                 Segmento AL1 = new Segmento();
                 AL1 = soyAL1(segmento, AL1);

                /*for (int i = 0; i < AL1.campos.Capacity; i++)
                {
                    Console.WriteLine(AL1.campos[i].nombre + ":" + AL1.campos[i].data);
                }*/
                if ((AL1.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true))) && (AL1.camposobligados.Count == 2))
                {
                     AL1.errorText="Todos los obligados en AL1 SI se encuentran en el mensaje";
                 }
                 else { AL1.errorText ="Todos los obligados en AL1 NO se encuentran en el mensaje"; }
                segmentos1.Add(AL1);
            }
             
             else if (String.Equals(segmento[0], "ORC"))
             {
                 Segmento ORC = new Segmento();
                 ORC = soyORC(segmento, ORC);

                /*for (int i = 0; i < ORC.campos.Capacity; i++)
                {
                    Console.WriteLine(ORC.campos[i].nombre + ":" + ORC.campos[i].data);
                }*/

                if ((ORC.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true))) && (ORC.camposobligados.Count == 2))
                {
                     ORC.errorText="Todos los obligados en ORC SI se encuentran en el mensaje";
                 }
                 else { ORC.errorText = "Todos los obligados en ORC NO se encuentran en el mensaje"; }
                segmentos1.Add(ORC);
            }

             
             else if (String.Equals(segmento[0], "DG1"))
             {
                 Segmento DG1 = new Segmento();
                 DG1 = soyDG1(segmento, DG1);

                /*for (int i = 0; i < DG1.campos.Capacity; i++)
                {
                    Console.WriteLine(DG1.campos[i].nombre + ":" + DG1.campos[i].data);
                }*/

                if ((DG1.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true))) && (DG1.camposobligados.Count == 2))
                {
                     DG1.errorText="Todos los obligados en DG1 SI se encuentran en el mensaje";
                 }
                 else { DG1.errorText = "Todos los obligados en DG1 NO se encuentran en el mensaje"; }
                segmentos1.Add(DG1);
            }
             
             else if (String.Equals(segmento[0], "OBX"))
             {
                 Segmento OBX = new Segmento();
                 OBX = soyOBX(segmento, OBX);
                 
                 /*for (int i = 0; i < OBX.campos.Capacity; i++)
                 {
                     Console.WriteLine(OBX.campos[i].nombre + ":" + OBX.campos[i].data);
                 }*/

                if ((OBX.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true))) && (OBX.camposobligados.Count == 3))
                {
                     OBX.errorText="Todos los obligados en OBX SI se encuentran en el mensaje";
                 }
                 else { OBX.errorText = "Todos los obligados en OBX NO se encuentran en el mensaje"; }
                segmentos1.Add(OBX);
            }

             
             else if (String.Equals(segmento[0], "CTI"))
             {
                 Segmento CTI = new Segmento();
                 CTI = soyCTI(segmento, CTI);
                 
                /*for (int i = 0; i < CTI.campos.Capacity; i++)
                {
                    Console.WriteLine(CTI.campos[i].nombre + ":" + CTI.campos[i].data);
                }*/

                if ((CTI.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true))) && (CTI.camposobligados.Count == 1))
                {
                     CTI.errorText="Todos los obligados en CTI SI se encuentran en el mensaje";
                 }
                 else { CTI.errorText ="Todos los obligados en CTI NO se encuentran en el mensaje"; }
                segmentos1.Add(CTI);
            }
             
             else if (String.Equals(segmento[0], "BLG"))
             {
                 Segmento BLG = new Segmento();
                 BLG = soyBLG(segmento, BLG);
                 
                /* for (int i = 0; i < BLG.campos.Capacity; i++)
                 {
                     Console.WriteLine(BLG.campos[i].nombre + ":" + BLG.campos[i].data);
                 }*/

                if (BLG.camposobligados.All(y => !Boolean.Equals(y.isEmpty, true)))
                {
                     BLG.errorText="Todos los obligados en BLG SI se encuentran en el mensaje";
                 }
                 else { BLG.errorText = "Todos los obligados en BLG  NO se encuentran en el mensaje"; }
                segmentos1.Add(BLG);
            }

             else
             {
                 Console.WriteLine("Soy segmento desconocido");
             }
         }

         public bool estavacio(string data)
         {
             bool t = false;
             if (string.Equals(data, ""))
             {
                 t = true;
             }
             else { t = false; }

             return t;
         }

        public Segmento soyMSH(string[] segmento, Segmento MSH, char soydelimitador)
        {
            List<Campo> auxobligadosMSH = new List<Campo>();
            // Campo[] auxobligadosMSH = new Campo[6];
            //Campo[] auxMSH = new Campo[segmento.Length];
            List<Campo> auxMSH = new List<Campo>();
            
            string[] nombresMSH = new string[] { "Segmento", "Field separator", "Encoding Characters", "Sending Application", "Sending Facility", "Receiving Application", "Receiving Facility","Date / Time of Message", "Security", "Message Type", "Message Control ID",
             "Processing ID","Version ID","Sequence Number","Continuation Pointer","Accept Acknowledgement Type","Application Acknowledgement Type","Country Code","Character Set","Principal Language of Message"};
            Campo campo3 = new Campo();
            campo3.data = segmento[0];
            campo3.isEmpty = estavacio(campo3.data);
            campo3.nombre = nombresMSH[0];
            auxMSH.Add(campo3);

            Campo campo2 = new Campo();

            string cString = soydelimitador.ToString();
            campo2.data = cString;
            campo2.isEmpty = estavacio(campo2.data);
            campo2.nombre = nombresMSH[1];
            auxMSH.Add(campo2);
            auxobligadosMSH.Add(campo2);

            for (int i = 1; i < segmento.Length; i++)
            {
                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresMSH[i + 1];
                auxMSH.Add (campo1);
                

                if (i == 1)
                {

                    auxobligadosMSH.Add(campo1);
                }
                else if (i == 8)
                {
                    auxobligadosMSH.Add(campo1);
                }
                else if (i == 9)
                {
                    auxobligadosMSH.Add(campo1);
                }
                else if (i == 10)
                {
                    auxobligadosMSH.Add(campo1);
                }
                else if (i == 11)
                {
                    auxobligadosMSH.Add(campo1);
                }




            }

            /*for (int i = 0; i < auxMSH.Length; i++)
            {
                MSH.campos.Add(auxMSH[i]);
            }
            for (int i = 0; i < auxobligadosMSH.Length; i++)
            {
                MSH.camposobligados.Add(auxobligadosMSH[i]);
            }*/
            MSH.campos = auxMSH;
            MSH.camposobligados = auxobligadosMSH;
        
             return MSH;

         }

        public Segmento soyNTE(string[] segmento, Segmento NTE)
        {
            /* Campo[] auxobligadosNTE = new Campo[0];
             Campo[] auxNTE = new Campo[segmento.Length];*/

            List<Campo> auxNTE = new List<Campo>();

            List<Campo> auxobligadosNTE = new List<Campo>();
            string[] nombresNTE = new string[] { "Segmento", "Set ID - Notes and Comments", "Source of Comment", "Comment" };
            for (int i = 0; i < segmento.Length; i++)
            {
                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresNTE[i];
                auxNTE.Add(campo1);
               // auxNTE[i] = campo1;

            }

            /*for (int i = 0; i < auxNTE.Length; i++)
            {
                NTE.campos.Add(auxNTE[i]);
            }
            for (int i = 0; i < auxobligadosNTE.Length; i++)
            {
                NTE.camposobligados.Add(auxobligadosNTE[i]);
            }
            */
            NTE.campos = auxNTE;
             NTE.camposobligados = auxobligadosNTE;

            return NTE;

        }

        public Segmento soyPID(string[] segmento, Segmento PID)
        {
            /*Campo[] auxobligadosPID = new Campo[2];
            Campo[] auxPID = new Campo[segmento.Length];*/
            List<Campo> auxPID = new List<Campo>();
            List<Campo> auxobligadosPID = new List<Campo>();
            String[] nombresPID = new String[] { "Segmento", "Set ID - Patient ID", "Patient ID (External ID)", "Patient ID (Internal ID)", "Alternate Patient ID", "Patient Name", "Mother's Maiden Name", "Date of Birth", "Sex", "Patient Alias", "Race",
             "Patient Address","County Code","Phone Number - Home","Phone Number - Business","Primary Language","Marital Status","Religion","Patient Account Number","SSN Number - Patient","Driver's License Number",
             "Mother's Identifier","Ethnic Group","Birth Place","Multiple Birth Indicator","Birth Order","Citizenship","Veterans Military Status","Nationality Code","Patient Death Date and Time","Patient Death Indicator"};

            for (int i = 0; i < segmento.Length; i++)
            {
                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresPID[i];
                auxPID.Add(campo1);
                if (i == 3)
                {
                    auxobligadosPID.Add(campo1);
                }
                else if (i == 5)
                {
                    auxobligadosPID.Add(campo1);
                }


            }

            /*for (int i = 0; i < auxPID.Length; i++)
            {
                PID.campos.Add(auxPID[i]);
            }
            for (int i = 0; i < auxobligadosPID.Length; i++)
            {
                PID.camposobligados.Add(auxobligadosPID[i]);
            }*/

            PID.campos = auxPID;
             PID.camposobligados = auxobligadosPID;

            return PID;
        }

        public Segmento soyPD1(string[] segmento, Segmento PD1)
        {
            /* Campo[] auxobligadosPD1 = new Campo[0];
             Campo[] auxPD1 = new Campo[segmento.Length];*/
            List<Campo> auxPD1 = new List<Campo>();
            List<Campo> auxobligadosPD1 = new List<Campo>();
            String[] nombresPID = new String[] {"Segmento", "Living Dependency", "Living Arrangement", "Patient Primary Facility", "Patient Primary Care Provider Name & ID No.", "Student Indicator", "Handicap", "Living Will", "Organ Donor", "Separate Bill","Duplicate Patient",
             "Publicity Indicator","Protection Indicator"};

            for (int i = 0; i < segmento.Length; i++)
            {
                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresPID[i];
                auxPD1.Add(campo1);

            }

           /* for (int i = 0; i < auxPD1.Length; i++)
            {
                PD1.campos.Add(auxPD1[i]);
            }
            for (int i = 0; i < auxobligadosPD1.Length; i++)
            {
                PD1.camposobligados.Add(auxobligadosPD1[i]);
            }*/

            PD1.campos = auxPD1;
             PD1.camposobligados = auxobligadosPD1;

            return PD1;
        }

        public Segmento soyPV1(string[] segmento, Segmento PV1)
        {
            /* Campo[] auxobligadosPV1 = new Campo[1];
             Campo[] auxPV1 = new Campo[segmento.Length];*/
            List<Campo> auxPV1 = new List<Campo>();
            List<Campo> auxobligadosPV1 = new List<Campo>();
            String[] nombresPV1 = new String[] { "Segmento", "Set ID - Patient Visit", "Patient Class", "Assigned Patient Location", "Admission Type", "Preadmit Number",
             "Prior Patient Location","Attending Doctor","Referring Doctor","Consulting Doctor","Hospital Service","Temporary Location","Preadmit Test Indicator","Readmission Indicator","Admit Source",
             "Ambulatory Status","VIP Indicator","Admitting Doctor","Patient Type","Visit Number","Financial Class","Charge Price Indicator","Courtesy Code","Credit Rating","Contract Code","Contract Effective Date","Contract Amount",
             "Contract Period","Interest Code","Transfer to Bad Debt Code","Transfer to Bad Debt Date","Bad Debt Agency Code","Bad Debt Transfer Amount","Bad Debt Recovery Amount","Delete Account Indicator","Delete Account Date","Discharge Disposition",
             "Discharged to Location","Diet Type","Servicing Facility","Bed Status","Account Status","Pending Location","Prior Temporary Location","Admit Date/Time","Discharge Date/Time","Current Patient Balance","Total Charges","Total Adjustments",
            "Total Payments","Alternate Visit ID","Visit Indicator","Other Healthcare Provider"};



            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresPV1[i];
                auxPV1.Add(campo1);
                if (i == 2)
                {
                    auxobligadosPV1.Add(campo1);
                }


            }

            /*for (int i = 0; i < auxPV1.Length; i++)
            {
                PV1.campos.Add(auxPV1[i]);
            }
            for (int i = 0; i < auxobligadosPV1.Length; i++)
            {
                PV1.camposobligados.Add(auxobligadosPV1[i]);
            }
            */
            PV1.campos = auxPV1;
             PV1.camposobligados = auxobligadosPV1;

            return PV1;
        }
        public Segmento soyPV2(string[] segmento, Segmento PV2)
        {
            /*Campo[] auxobligadosPV2 = new Campo[0];
            Campo[] auxPV2 = new Campo[segmento.Length];*/
            List<Campo> auxPV2 = new List<Campo>();
            List<Campo> auxobligadosPV2 = new List<Campo>();

            String[] nombresPV2 = new String[] {"Segmento", "Prior Pending Location", "Accommodation Code", "Admit Reason", "Transfer Reason", "Patient Valuables", "Patient Valuables Location", "Visit User Code",
             "Expected Admit Date","Expected Discharge Date","Estimated Length of Inpatient Stay","Actual Length of Inpatient Stay","Visit Description","Referral Source Code","Previous Service Date","Employment Illness Related Indicator","Purge Status Code",
             "Purge Status Date","Special Program Code","Retention Indicator","Expected Number of Insurance Plans","Visit Publicity Code","Visit Protection Indicator","Clinic Organization Name","Patient Status Code","Visit Priority Code","Previous Treatment Date",
             "Expected Discharge Disposition","Signature on File Date","First Similar Illness Date","Patient Charge Adjustment Code","Recurring Service Code","Billing Media Code","Expected Surgery Date & Time","Military Partnership Code","Military Non-Availabiltiy Code",
             "Newborn Baby Indicator","Baby Detained Indicator"};

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresPV2[i];
                auxPV2.Add(campo1);

            }

            /*for (int i = 0; i < auxPV2.Length; i++)
            {
                PV2.campos.Add(auxPV2[i]);
            }
            for (int i = 0; i < auxobligadosPV2.Length; i++)
            {
                PV2.camposobligados.Add(auxobligadosPV2[i]);
            }*/

            PV2.campos = auxPV2;
             PV2.camposobligados = auxobligadosPV2;

            return PV2;
        }
        public Segmento soyIN1(string[] segmento, Segmento IN1)
        {
            /*Campo[] auxobligadosIN1 = new Campo[2];
            Campo[] auxIN1 = new Campo[segmento.Length];*/
            List<Campo> auxIN1 = new List<Campo>();
            List<Campo> auxobligadosIN1 = new List<Campo>();

            String[] nombresIN1 = new String[] {"Segmento", "Set ID - Insurance", "Insurance Plan ID", "Insurance Company ID", "Insurance Company Name", "Insurance Company Address", "Insurance Co. Contact Ppers", "Insurance Co Phone Number", "Group Number", "Group Number", "Insured's group employer ID",
             "Insured's Group Emp Name","Plan Effective Date","Plan Expiration Date","Authorization Information","Plan Type","Name of Insured","Insured's Relationship to Patient","Insured's Date of Birth","Insured's Address","Assignment of Benefits","Coordination of Benefits","Coord of Ben. Priority","Notice of Admission Code",
             "Rpt of Eigibility Code","Rpt of Eligibility Date","Release Information Code","Pre-Admit Cert","Verification Date/Time","Verification By","Type of Agreement Code","Billing Status","Lifetime Reserve Days","Delay before lifetime reserve days","Company Plan Code","Policy Number","Policy Deductible","Policy Limit - Amount",
             "Policy Limit - Days","Room Rate - Semi-Private","Room Rate - Private","Insured's Employment Status","Insured's Sex","Insured's Employer Address","Verification Status","Prior Insurance Plan ID","Coverage Type","Handicap","Insured's ID Number"};

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresIN1[i];
                auxIN1.Add(campo1);
                if (i == 1)
                {
                    auxobligadosIN1.Add(campo1);
                }
                else if (i == 3)
                {
                    auxobligadosIN1.Add(campo1);
                }
            }

            /*for (int i = 0; i < auxIN1.Length; i++)
            {
                IN1.campos.Add(auxIN1[i]);
            }
            for (int i = 0; i < auxobligadosIN1.Length; i++)
            {
                IN1.camposobligados.Add(auxobligadosIN1[i]);
            }*/

            IN1.campos = auxIN1;
            IN1.camposobligados = auxobligadosIN1;

            return IN1;
        }

        public Segmento soyIN2(string[] segmento, Segmento IN2)
        {
            /*Campo[] auxobligadosIN2 = new Campo[0];
            Campo[] auxIN2 = new Campo[segmento.Length];*/
            List<Campo> auxIN2 = new List<Campo>();
            List<Campo> auxobligadosIN2 = new List<Campo>();
            String[] nombresIN2 = new String[] {"Segmento", "Insured's Employee ID", "Insured's Social Security Number", "Insured's Employer Name", "Employer Information Data", "Mail Claim Party", "Medicare Health Ins Card Number", "Medicaid Case Name", "Medicaid Case Number", "Champus Sponsor Name", "Champus ID Number",
             "Dependent of Champus Recipient","Champus Organization","Champus Station","Champus Service","Champus Rank/Grade","Champus Status","Champus Retire Date","Champus Non-Avail Cert on File","Baby Coverage","Combine Baby Bill","Blood Deductible","Special Coverage Approval Name","Special Coverage Approval Title","Non-Covered Insurance Code",
             "Payor ID","Payor Subscriber ID","Eligibility Source","Room Coverage Type/Amount","Policy Type/Amount","Daily Deductible","Living Dependency","Ambulatory Status","Citizenship","Primary Language","Living Arrangement","Publicity Indicator","Protection Indicator","Student Indicator","Religion","Mother s Maiden Name","Nationality Code",
             "Ethnic Group","Marital Status","Employment Start Date","Employment Stop Date","Job Title","Job Code/Class","Job Status","Employer Contact Person Name","Employer Contact Person Phone Number","Employer Contact Reason","Insured s Contact Person s Name","Insured s Contact Person Telephone Number","Insured s Contact Person Reason",
             "Relationship To The Patient Start Date","Relationship To The Patient Stop Date","Insurance Co. Contact Reason","Insurance Co. Contact Phone Number","Policy Scope","Policy Source","Patient Member Number","Patient Member Number","Guarantor s Relationship To Insured","Insured s Telephone Number - Home","Insured s Employer Telephone Number",
             "Military Handicapped Program","Suspend Flag","Co-pay Limit Flag","Stoploss Limit Flag","Insured Organization Name And ID","Insured Employer Organization Name And ID","Race","Patient Relationship to Insured"};

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresIN2[i];
                auxIN2.Add(campo1);

            }
            /*for (int i = 0; i < auxIN2.Length; i++)
            {
                IN2.campos.Add(auxIN2[i]);
            }
            for (int i = 0; i < auxobligadosIN2.Length; i++)
            {
                IN2.camposobligados.Add(auxobligadosIN2[i]);
            }*/

            IN2.campos = auxIN2;
             IN2.camposobligados = auxobligadosIN2;

            return IN2;
        }
        public Segmento soyIN3(string[] segmento, Segmento IN3)
        {
            /*Campo[] auxobligadosIN3 = new Campo[1];
            Campo[] auxIN3 = new Campo[segmento.Length];*/
            List<Campo> auxIN3 = new List<Campo>();
            List<Campo> auxobligadosIN3 = new List<Campo>();

            String[] nombresIN3 = new String[] {"Segmento", "Set ID - Insurance Certification", "Certification Number", "Certified By", "Certification Required", "Penalty", "Certification Date/Time", "Certification Modify Date/Time", "Operator", "Certification Begin Date", "Certification End Date", "Days",
             "Non-Concur Code/Description","Non-Concur Effective Date/Time","Physician Reviewer","Certification Contact","Certification Contact Phone Number","Appeal Reason","Certification Agency","Certification Agency Phone Number","Pre-Certification required/Window","Case Manager","Second Opinion Date",
             "Second Opinion Status","Second Opinion Documentation Received","Second Opinion Physician"};

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresIN3[i];
                auxIN3.Add(campo1);
                if (i == 1)
                {
                    auxobligadosIN3.Add(campo1);
                }
            }

            /*for (int i = 0; i < auxIN3.Length; i++)
            {
                IN3.campos.Add(auxIN3[i]);
            }
            for (int i = 0; i < auxobligadosIN3.Length; i++)
            {
                IN3.camposobligados.Add(auxobligadosIN3[i]);
            }*/

            IN3.campos = auxIN3;
             IN3.camposobligados = auxobligadosIN3;

            return IN3;
        }

        public Segmento soyGT1(string[] segmento, Segmento GT1)
        {
            /*Campo[] auxobligadosGT1 = new Campo[2];
            Campo[] auxGT1 = new Campo[segmento.Length];*/
            List<Campo> auxGT1 = new List<Campo>();
            List<Campo> auxobligadosGT1 = new List<Campo>();
            String[] nombresPV2 = new String[] {"Segmento", "Set ID - Guarantor", "Guarantor Number", "Guarantor Name", "Guarantor Spouse Name", "Guarantor Address", "Guarantor Ph Num- Home", "Guarantor Ph Num-Business", "Guarantor Date/Time of Birth", "Guarantor Sex", "Guarantor Type",
             "Guarantor Relationship","Guarantor SSN","Guarantor Date - Begin","Guarantor Date - End","Guarantor Priority","Guarantor Employer Name","Guarantor Employer Address","Guarantor Employ Phone Number","Guarantor Employee ID Number","Guarantor Employment Status",
             "Guarantor Organization","Guarantor Billing Hold Flag","Guarantor Credit Rating Code","Guarantor Death Date And Time","Guarantor Death Flag","Guarantor Charge Adjustment Code","Guarantor Household Annual Income","Guarantor Household Size","Guarantor Employer ID Number","Guarantor Marital Status Code",
             "Guarantor Hire Effective Date","Employment Stop Date","Living Dependency","Ambulatory Status","Citizenship","Primary Language","Living Arrangement","Publicity Indicator","Protection Indicator","Student Indicator",
             "Religion","Mother s Maiden Name","Nationality Code","Ethnic Group","Contact Person's Name","Contact Person s Telephone Number","Contact Reason","Contact Relationship Code","Job Title","Job Code/Class",
             "Guarantor Employer's Organization Name","Handicap","Job Status","Guarantor Financial Class","Guarantor Race"};

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresPV2[i];
                auxGT1.Add(campo1);
                if (i == 1)
                {
                    auxobligadosGT1.Add(campo1);
                }
                else if (i == 3)
                {
                    auxobligadosGT1.Add(campo1);
                }
            }

            /*for (int i = 0; i < auxGT1.Length; i++)
            {
                GT1.campos.Add(auxGT1[i]);
            }
            for (int i = 0; i < auxobligadosGT1.Length; i++)
            {
                GT1.camposobligados.Add(auxobligadosGT1[i]);
            }*/

            GT1.campos = auxGT1;
             GT1.camposobligados = auxobligadosGT1;

            return GT1;
        }
        public Segmento soyAL1(string[] segmento, Segmento AL1)
        {
            /*Campo[] auxobligadosAL1 = new Campo[2];
            Campo[] auxAL1 = new Campo[segmento.Length];*/
            List<Campo> auxAL1 = new List<Campo>();
            List<Campo> auxobligadosAL1 = new List<Campo>();
            String[] nombresAL1 = new String[] { "Segmento", "Set ID - AL1", "Allergy Type", "Allergy Code/Mnemonic/ Description", "Allergy Severity", "Allergy Reaction", "Identification Date" };

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresAL1[i];
                auxAL1.Add(campo1);
                if (i == 1)
                {
                    auxobligadosAL1.Add(campo1);
                }
                else if (i == 3)
                {
                    auxobligadosAL1.Add(campo1);
                }
            }

            /*for (int i = 0; i < auxAL1.Length; i++)
            {
                AL1.campos.Add(auxAL1[i]);
            }
            for (int i = 0; i < auxobligadosAL1.Length; i++)
            {
                AL1.camposobligados.Add(auxobligadosAL1[i]);
            }*/

             AL1.campos = auxAL1;
             AL1.camposobligados = auxobligadosAL1;

            return AL1;
        }

        public Segmento soyORC(string[] segmento, Segmento ORC)
        {
            /*Campo[] auxobligadosORC = new Campo[2];
            Campo[] auxORC = new Campo[segmento.Length];*/
            List<Campo> auxORC= new List<Campo>();
            List<Campo> auxobligadosORC = new List<Campo>();
            String[] nombresORC = new String[] {"Segmento", "Order Control", "Placer Order Number", "Filler Order Number", "Placer Group Number", "Order Status", "Response Flag", "Quantity/Timing", "Parent Order", "Date/Time of Transaction", "Entered By",
             "Verified By","Ordering Provider","Enterer's Location","Call Back Phone Number","Order Effective Date/Time","Order Control Code Reason","Entering Organization","Entering Device","Action By"};

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresORC[i];
                auxORC.Add(campo1);
                if (i == 1)
                {
                    auxobligadosORC.Add(campo1);
                }
                else if (i == 7)
                {
                    auxobligadosORC.Add(campo1);
                }
            }

           /* for (int i = 0; i < auxORC.Length; i++)
            {
                ORC.campos.Add(auxORC[i]);
            }
            for (int i = 0; i < auxobligadosORC.Length; i++)
            {
                ORC.camposobligados.Add(auxobligadosORC[i]);
            }*/

            ORC.campos = auxORC;
             ORC.camposobligados = auxobligadosORC;

            return ORC;
        }

        public Segmento soyDG1(string[] segmento, Segmento DG1)
        {
            /*Campo[] auxobligadosDG1 = new Campo[2];
            Campo[] auxDG1 = new Campo[segmento.Length];*/
            List<Campo> auxDG1 = new List<Campo>();
            List<Campo> auxobligadosDG1 = new List<Campo>();
            String[] nombresDG1 = new String[] {"Segmento", "Set ID - Diagnosis", "Diagnosis Coding Method", "Diagnosis Code", "Diagnosis Description", "Diagnosis Date/Time", "Diagnosis Type", "Major Diagnostic Category", "Diagnostic Related Group", "DRG Approval Indicator", "DRG Grouper Review Code",
             "Outlier Type","Outlier Days","Outlier Cost","Grouper Version and Type","Diagnosis Priority","Diagnosing Clinician","Diagnosis Classification","Confidential Indicator","Attestation Date/Time"};

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresDG1[i];
                auxDG1.Add(campo1);
                if (i == 1)
                {
                    auxobligadosDG1.Add(campo1);
                }
                else if (i == 6)
                {
                    auxobligadosDG1.Add(campo1);
                }
            }

            /*for (int i = 0; i < auxDG1.Length; i++)
            {
                DG1.campos.Add(auxDG1[i]);
            }
            for (int i = 0; i < auxobligadosDG1.Length; i++)
            {
                DG1.camposobligados.Add(auxobligadosDG1[i]);
            }*/

             DG1.campos = auxDG1;
             DG1.camposobligados = auxobligadosDG1;

            return DG1;
        }

        public Segmento soyOBX(string[] segmento, Segmento OBX)
        {
            /*Campo[] auxobligadosOBX = new Campo[3];
            Campo[] auxOBX = new Campo[segmento.Length];*/
            List<Campo> auxOBX = new List<Campo>();
            List<Campo> auxobligadosOBX = new List<Campo>();
            String[] nombresOBX = new String[] {"Segmento", "Set ID - OBX", "Value Type", "Observation Identifier", "Observation Sub-ID", "Observation Value", "Units", "References Range", "Abnormal Flags", "Probability", "Nature of Abnormal Test",
             "Observ Result Status","Date Last Obs Normal Values","User Defined Access Checks","Date/Time of the Observation","Producer's ID","Responsible Observer","Observation Method"};

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresOBX[i];
                auxOBX.Add(campo1);
                if (i == 2)
                {
                    auxobligadosOBX.Add(campo1);
                }
                else if (i == 3)
                {
                    auxobligadosOBX.Add(campo1);
                }
                else if (i == 11)
                {
                    auxobligadosOBX.Add(campo1);
                }

            }

            /*for (int i = 0; i < auxOBX.Length; i++)
            {
                OBX.campos.Add(auxOBX[i]);
            }
            for (int i = 0; i < auxobligadosOBX.Length; i++)
            {
                OBX.camposobligados.Add(auxobligadosOBX[i]);
            }
            */
            OBX.campos = auxOBX;
             OBX.camposobligados = auxobligadosOBX;

            return OBX;
        }

        public Segmento soyCTI(string[] segmento, Segmento CTI)
        {
            /* Campo[] auxobligadosCTI = new Campo[1];
             Campo[] auxCTI = new Campo[segmento.Length];*/
            List<Campo> auxCTI = new List<Campo>();
            List<Campo> auxobligadosCTI = new List<Campo>();
            String[] nombresCTI = new String[] { "Segmento", "Sponsor Study ID", "Study Phase Identifier", "Study Scheduled Time Point" };

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresCTI[i];
                auxCTI.Add(campo1);
                if (i == 1)
                {
                    auxobligadosCTI.Add(campo1);
                }
            }

            /*for (int i = 0; i < auxCTI.Length; i++)
            {
                CTI.campos.Add(auxCTI[i]);
            }
            for (int i = 0; i < auxobligadosCTI.Length; i++)
            {
                CTI.camposobligados.Add(auxobligadosCTI[i]);
            }*/

            CTI.campos = auxCTI;
             CTI.camposobligados = auxobligadosCTI;

            return CTI;
        }
        public Segmento soyBLG(string[] segmento, Segmento BLG)
        {
            /*Campo[] auxobligadosBLG = new Campo[0];
            Campo[] auxBLG = new Campo[segmento.Length];*/
            List<Campo> auxBLG = new List<Campo>();
            List<Campo> auxobligadosBLG = new List<Campo>();
            String[] nombresBLG = new String[] { "Segmento", "When to Charge", "Charge Type", "Account ID" };

            for (int i = 0; i < segmento.Length; i++)
            {

                Campo campo1 = new Campo();
                campo1.data = segmento[i];
                campo1.isEmpty = estavacio(campo1.data);
                campo1.nombre = nombresBLG[i];
                auxBLG.Add(campo1);

            }

            /*for (int i = 0; i < auxBLG.Length; i++)
            {
                BLG.campos.Add(auxBLG[i]);
            }
            for (int i = 0; i < auxobligadosBLG.Length; i++)
            {
                BLG.camposobligados.Add(auxobligadosBLG[i]);
            }*/

            BLG.campos = auxBLG;
             BLG.camposobligados = auxobligadosBLG;

            return BLG;
        }

        /* public List<Campo> getList()
         {

             return campos;
         }
         */


        public List<Segmento> getList()
        {

            return segmentos1;
        }

    }
}