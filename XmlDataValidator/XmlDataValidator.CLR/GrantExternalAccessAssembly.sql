/*
Выполнить после сборки и до публикации
*/
ALTER DATABASE CUST SET TRUSTWORTHY ON;
GO
USE [master];
GO
CREATE ASYMMETRIC KEY [XmlDataValidator.CLR.Key]
  AUTHORIZATION [dbo]
  FROM EXECUTABLE FILE = 'D:\Solutions\fgis_usmt\XmlDataValidator\XmlDataValidator.CLR\bin\Debug\XmlDataValidator.CLR.dll';
GO
CREATE LOGIN [XmlDataValidator.CLR.Login]
  FROM ASYMMETRIC KEY [XmlDataValidator.CLR.Key];
GO
GRANT EXTERNAL ACCESS ASSEMBLY TO [XmlDataValidator.CLR.Login]; 
GO

/*
Select [dbo].[SqlXmlDataValidator]('http://192.168.1.50:9001/api/validate', 'AttractRegistration', '1.1', 'Привет, МИР!')
*/