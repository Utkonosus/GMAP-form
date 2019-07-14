 
 CREATE DATABASE Vehicle_loc1
 GO
 
 USE Vehicle_loc1
 
 CREATE TABLE dbo.Coordinates  
   (VehicleID int PRIMARY KEY NOT NULL,  
   VehicleName varchar(25) NOT NULL,  
   Latitude real NULL,  
   Longitude real NULL)  
 
INSERT dbo.Coordinates (VehicleID, VehicleName, Latitude, Longitude)  
    VALUES (1, 'Vehicle1', 55.011447 ,  82.925846)  
  
INSERT dbo.Coordinates (VehicleID, VehicleName, Latitude, Longitude)  
    VALUES (2, 'Vehicle2', 55.000357 ,  82.925846)  
  
INSERT dbo.Coordinates (VehicleID, VehicleName, Latitude, Longitude)  
    VALUES (3, 'Vehicle3', 55.009267 ,  82.935846)  
  
INSERT dbo.Coordinates (VehicleID, VehicleName, Latitude, Longitude)  
    VALUES (4, 'Vehicle5', 55.008177 ,  82.900846)  
  
INSERT dbo.Coordinates (VehicleID, VehicleName, Latitude, Longitude)  
    VALUES (5, 'Vehicle6', 55.006587 ,  82.880000)   
 
SELECT * 
FROM dbo.Coordinates
GO
