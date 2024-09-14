=========================================================
=  STOREINFO.WEB APP PROJECT SETUP AND CONFIGURATIONS:  =
=========================================================


A.  ADDITIONAL SETUP:
=====================

 1. Need to download and install "Microsoft Access Database Engine 2016 Redistributable" 
    (For Excel File Connection and Reading)
   
   - Download Link:   https://www.microsoft.com/en-us/download/details.aspx?id=54920
   - Download File:   accessdatabaseengine_X64.exe

   
IMPORTANT NOTE:
---------------
1. Modify the folder paths in the "Log4Net.config" file located in the "\StoreInfo.Web\Configuration" folder, 
   below sample:
   <file value="C:\_PROJECTS\_THREEPEAKS\_LOGS\Exception_.txt" />
   
2. Target Directory value is in the "appsettings.json" file to be configured for future changes. This is for the 
   excel file upload mechanism destination folder.



After everything has been prepared/completed, the application should now work. Thanks!



B.  TECH STACK:
===============
 1. MVC .Net 6
 2. Filters (for centralized exception handling)
 3. Log4net (for file-based exception logging mechanism)
 4. xUnit (for unit test)
 5. Moq (for mocking objects in unit test)
 6. N-tier architecture
