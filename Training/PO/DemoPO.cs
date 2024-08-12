using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;

namespace Training.PO
{
    internal class DemoPO :Ede.Uof.Utility.Data.BasePersistentObject
    {
   
        internal DataTable GetUserData(string groupId)
        {
           

            string cmdTxt = @"SELECT ACCOUNT ,
                                     NAME 
                            FROM
                                TB_EB_USER 
                            INNER JOIN TB_EB_EMPL_DEP
                                ON TB_EB_USER.USER_GUID = TB_EB_EMPL_DEP.USER_GUID
                            WHERE GROUP_ID = @GROUP_ID
                                ";

            this.m_db.AddParameter("@GROUP_ID", groupId);

            DataTable dt = new DataTable();

            dt.Load(this.m_db.ExecuteReader(cmdTxt));

            return dt;

        }

      
        internal void InsertTaskData(DataRow dr)
        {
            string cmdTxt = @"  INSERT INTO [dbo].[TB_DEMO_TASK]  
(	 [FILE_NAME] , 
	 [TYPE_NAME] , 
	 [EXECUTE_TIME] , 
	 [PARAMS]  
) 
 VALUES 
 (	 @FILE_NAME , 
	 @TYPE_NAME , 
	 @EXECUTE_TIME , 
	 @PARAMS  
)";

            this.m_db.AddParameter("@FILE_NAME", dr["FILE_NAME"]);
            this.m_db.AddParameter("@TYPE_NAME", dr["TYPE_NAME"]);
            this.m_db.AddParameter("@EXECUTE_TIME", Convert.ToDateTime( dr["EXECUTE_TIME"]));
            this.m_db.AddParameter("@PARAMS", dr["PARAMS"]);

            this.m_db.ExecuteNonQuery(cmdTxt);

        }

        internal DataTable GetUserData()
        {
            string cmdTxt = @"SELECT ACCOUNT ,
                                     NAME ,TB_EB_USER.USER_GUID
                            FROM
                                TB_EB_USER 
                            INNER JOIN TB_EB_EMPL_DEP
                                ON TB_EB_USER.USER_GUID = TB_EB_EMPL_DEP.USER_GUID
                
                                ";



            DataTable dt = new DataTable();

            dt.Load(this.m_db.ExecuteReader(cmdTxt));

            return dt;
        }

        internal void InsertWsEndFormData(System.Data.DataRow dr)
        {
            string cmdTxt = @"  INSERT INTO [dbo].[TB_DEMO_WS_FORM]  
                                (	 [ID] , 
	                                 [ITEM_QTY] , 
	                                 [ITEM_PRICE] , 
	                                 [ITEM] , 
	                                 [DOC_NBR] , 
	                                 [FORM_RESULT]  
                                ) 
                                 VALUES 
                                 (	 @ID , 
	                                 @ITEM_QTY , 
	                                 @ITEM_PRICE , 
	                                 @ITEM , 
	                                 @DOC_NBR , 
	                                 @FORM_RESULT  
                                )";

            this.m_db.AddParameter("@ID", dr["ID"]);
            this.m_db.AddParameter("@ITEM_QTY", dr["ITEM_QTY"]);
            this.m_db.AddParameter("@ITEM_PRICE", dr["ITEM_PRICE"]);
            this.m_db.AddParameter("@ITEM", dr["ITEM"]);
            this.m_db.AddParameter("@DOC_NBR", dr["DOC_NBR"]);
            this.m_db.AddParameter("@FORM_RESULT", dr["FORM_RESULT"]);

            this.m_db.ExecuteNonQuery(cmdTxt);

        }

        internal void InsertDDLStartFormData(DemoDataSet.TB_DEMO_DLL_FORMRow dr)
        {
            string cmdTxt = @"  INSERT INTO [dbo].[TB_DEMO_DLL_FORM]  
                                        (	 [ID] , 
	                                         [ITEM_QTY] , 
	                                         [ITEM_PRICE] , 
	                                         [ITEM] , 
	                                         [DOC_NBR] , 
	                                         [SIGN_STATIS] , 
	                                         [REMARK]  
                                        ) 
                                         VALUES 
                                         (	 @ID , 
	                                         @ITEM_QTY , 
	                                         @ITEM_PRICE , 
	                                         @ITEM , 
	                                         @DOC_NBR , 
	                                         @SIGN_STATIS , 
	                                         @REMARK  
                                        )";
           
            this.m_db.AddParameter("@ID", dr.ID);
            this.m_db.AddParameter("@ITEM_QTY", dr.ITEM_QTY);
            this.m_db.AddParameter("@ITEM_PRICE", dr.ITEM_PRICE);
            this.m_db.AddParameter("@ITEM", dr.ITEM);
            this.m_db.AddParameter("@DOC_NBR", dr.DOC_NBR);
            this.m_db.AddParameter("@SIGN_STATIS", dr.SIGN_STATIS);
            this.m_db.AddParameter("@REMARK", dr.REMARK);

            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        internal void UpdateFormStatus(string docNbr, string signStatus)
        {
            string cmdTxt = @"  UPDATE [dbo].[TB_DEMO_DLL_FORM]  
                             SET 
	                             [SIGN_STATIS] = @SIGN_STATIS  

                            WHERE 
	                            [DOC_NBR] = @DOC_NBR";

            this.m_db.AddParameter("@SIGN_STATIS", signStatus);
            this.m_db.AddParameter("@DOC_NBR", docNbr);

            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        internal void UpdateFormResult(string docNbr, string formResult)
        {
            string cmdTxt = @"  UPDATE [dbo].[TB_DEMO_DLL_FORM]  
                             SET 
	                             [FORM_RESULT] = @FORM_RESULT  

                            WHERE 
	                            [DOC_NBR] = @DOC_NBR";

            this.m_db.AddParameter("@FORM_RESULT", formResult);
            this.m_db.AddParameter("@DOC_NBR", docNbr);

            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        internal void InsertCurrency(CurrenyDataSet.TB_IAL_CURRENCYRow dr)
        {
            string cmdTxt = @"  INSERT INTO [dbo].[TB_IAL_CURRENCY]  
(	 [CURRENCY_ID] , 
	 [CURRENCY_NAME] , 
	 [MODIFYER]  
) 
 VALUES 
 (	 @CURRENCY_ID , 
	 @CURRENCY_NAME , 
	 @MODIFYER  
)";

            this.m_db.AddParameter("@CURRENCY_ID", dr.CURRENCY_ID);
            this.m_db.AddParameter("@CURRENCY_NAME", dr.CURRENCY_NAME);
            this.m_db.AddParameter("@MODIFYER", dr.MODIFYER);

            this.m_db.ExecuteNonQuery(cmdTxt);

        }

        internal CurrenyDataSet GetCurrency()
        {
            string cmdTxt = @" SELECT 
	 [CURRENCY_ID] , 
	 [CURRENCY_NAME] , 
	 [MODIFYER]  
 FROM [dbo].[TB_IAL_CURRENCY] ";

            CurrenyDataSet ds = new CurrenyDataSet();
            ds.Load(this.m_db.ExecuteReader(cmdTxt), LoadOption.OverwriteChanges,
                ds.TB_IAL_CURRENCY);
            return ds;

        }

        internal void DeleteCurrency(string id)
        {
            string cmdTxt = @" DELETE [dbo].[TB_IAL_CURRENCY] 
WHERE 
	[CURRENCY_ID] = @CURRENCY_ID";

            this.m_db.AddParameter("@CURRENCY_ID", id);

            this.m_db.ExecuteNonQuery(cmdTxt);

        }

        internal CurrenyDataSet GetCurrencyRate()
        {
            string cmdTxt = @"SELECT 	 TB_IAL_CURRENCY_RATE.[CURRENCY_ID] , 
[CURRENCY_NAME],
	 [CURRENCY_RATE] , 
	 [Year] , 
	 [Month] , 
	 TB_IAL_CURRENCY_RATE.[MODIFYER]  
 FROM TB_IAL_CURRENCY_RATE
INNER JOIN TB_IAL_CURRENCY
ON TB_IAL_CURRENCY_RATE.CURRENCY_ID=TB_IAL_CURRENCY.CURRENCY_ID";

            CurrenyDataSet ds = new CurrenyDataSet();
            ds.Load(this.m_db.ExecuteReader(cmdTxt), LoadOption.OverwriteChanges,
                               ds.TB_IAL_CURRENCY_RATE);
            return ds;
        }

        internal void InsertCurrencyRate(CurrenyDataSet.TB_IAL_CURRENCY_RATERow dr)
        {
            string cmdTxt = @"  INSERT INTO [dbo].[TB_IAL_CURRENCY_RATE]  
(	 [CURRENCY_ID] , 
	 [CURRENCY_RATE] , 
	 [Year] , 
	 [Month] , 
	 [MODIFYER]  
) 
 VALUES 
 (	 @CURRENCY_ID , 
	 @CURRENCY_RATE , 
	 @Year , 
	 @Month , 
	 @MODIFYER  
)";

            this.m_db.AddParameter("@CURRENCY_ID", dr.CURRENCY_ID);
            this.m_db.AddParameter("@CURRENCY_RATE", dr.CURRENCY_RATE);
            this.m_db.AddParameter("@Year", dr.Year);
            this.m_db.AddParameter("@Month", dr.Month);
            this.m_db.AddParameter("@MODIFYER", dr.MODIFYER);

            this.m_db.ExecuteNonQuery(cmdTxt);

        }

        internal void UpdateCurrencyRate(CurrenyDataSet.TB_IAL_CURRENCY_RATERow dr)
        {
            string cmdTxt = @"  UPDATE [dbo].[TB_IAL_CURRENCY_RATE]  
 SET 
	 [CURRENCY_RATE] = @CURRENCY_RATE , 
	 [MODIFYER] = @MODIFYER  

WHERE 
	[CURRENCY_ID] = @CURRENCY_ID
AND 
	[Year] = @Year
AND 
	[Month] = @Month";

            this.m_db.AddParameter("@CURRENCY_RATE", dr.CURRENCY_RATE);
            this.m_db.AddParameter("@MODIFYER", dr.MODIFYER);
            this.m_db.AddParameter("@CURRENCY_ID", dr.CURRENCY_ID);
            this.m_db.AddParameter("@Year", dr.Year);
            this.m_db.AddParameter("@Month", dr.Month);

            this.m_db.ExecuteNonQuery(cmdTxt);

        }
    }
}
