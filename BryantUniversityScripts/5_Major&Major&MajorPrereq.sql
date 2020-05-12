/*Majors*/

--Computer science
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.S. Computer Science ' , 1 ) 
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.S.  Management Information Systems ' , 1 ) 


--American Studies
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.A. American Studies. ' , 2 ) 
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.A. Asian Studies' , 2 ) 

--Biological Sciences
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.S. Biological Sciences ' , 3 ) 
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.S. Biochemistry' , 3 ) 

--Criminology
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.A. Criminology  ' , 4 ) 
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' Emergency Management & Homeland Security. ' , 4 ) 

--History & Philosophy
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.A. History ' , 5 ) 
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.A. Philosophy ' , 5 ) 

--Mathematics
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.S. Mathematics' , 6 ) 
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.S. Applied Mathematics and Statistics ' , 6 ) 

 --Psychology
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.A. Psychology ' , 7 ) 
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.S. Clinical Psychology. ' , 7 ) 

--School of Business
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.S. Business Administration ' , 8 ) 
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' B.S. Accounting ' , 8 ) 







/*Major Requirements */

--All CS Majors 1-2

--Department 1


--B.S. Computer Science

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 1 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 2 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 3 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 4 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 5 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 6 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 7 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 8 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 9 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 1 , 10) 

--B.S. Management Information Systems

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 1 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 2 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 3 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 4 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 5 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 6 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 7 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 8 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 9 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES   ( 2 , 10 ) 

--/*American Studies ---> 2-4 */

--B.A. American Studies

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 11 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 12 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 13 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 14 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 15 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 16 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 17) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 18 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 19 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 3 , 20) 

--B.A. Asian Studies
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 11 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 12 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 13 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 14 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 15 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 16 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 17) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 18 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 19 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 4 , 20) 


/*Biological Science ---> 5-6 */

--B.S. BioChemistry
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 21) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 22 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 23 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 24 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 25 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 26 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 27 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 28 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 29) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 5 , 30 ) 

--B.S. Biological Sciences

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 21) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 22 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 23 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 24 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 25 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 26 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 27 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 28 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 29) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 6 , 30 ) 




/*Criminology --->7-8*/


--B.A. Criminology

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 31) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 32 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 33 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 34 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 35 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 36 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 37 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 38 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 39 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 7 , 40 ) 

--Emergency Man & Homeland Sec

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 31) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 32 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 33 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 34 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 35 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 36 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 37 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 38 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 39 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES      ( 8 , 40 ) 


/*History 8 philosophy  ---> 9-10*/

--American History

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 41 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 42 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 43 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 44 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 45) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 46 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 47 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 48 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 49 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 9 , 50 ) 


--Bio & American His

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 41 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 42 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 43 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 44 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 45) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 46 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 47 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 48 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 49 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES       ( 10 , 50 ) 

/*Mathematics --> 9-10  */

--B.S. Mathematics

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 11 , 51 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 11 , 52 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 11 , 53 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 11 , 54 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 11 , 55 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        (11 , 56 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 11 , 57) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 11 , 58 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 11 , 59 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 11 , 60 ) 

-- B.S. Applied Mathematics and Statistics

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 12 , 51 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 12 , 52 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 12 , 53 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 12 , 54 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 12 , 55 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        (12 , 56 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 12 , 57) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 12 , 58 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 12 , 59 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES        ( 12 , 60 )  





/* Psychology*/

---B.A. Psychology

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 61 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 62 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 63) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 64) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 65 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 66 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 67 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 68 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 69) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 13 , 70 ) 

--B.S. Clinical Psychology

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 61 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 62 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 63) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 64) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 65 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 66 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 67 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 68 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 69) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES          ( 14 , 70 ) 

/*School of Business- --->  41-45 */

---- B.S. Business Admin

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 71) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 72 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 73 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 74 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 75) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 76) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 77 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 78 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 79 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 15 , 80 ) 





--B.S. Accounting

INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 71) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 72 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 73 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 74 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 75) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 76) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 77 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 78 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 79 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES           ( 16 , 80 ) 





































-----Major Pre-Requisite




---Mis&CS
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (1,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (2,1)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (3,2) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (4,2) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (5,4)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (6,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (7,4)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (8,7) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (9,8) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (10 ,9)

--American Studies

INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (11,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (12,11)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (13,12) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (14,13) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (15,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (16,16)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (17,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (18,16) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (19,18) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (20 ,19)


---Biology

INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (21,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (22,28)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (23,29) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (24,30) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (25,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (26,32)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (27,33)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (28,27) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (29,28) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (30 ,29)

---Criminology

INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (31,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (32,31)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (33,32) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (34,NULL) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (35,33)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (36,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (37,36)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (38,37)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (39,38)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (40,39)

---History & Philosophy

INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (41,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (42,41)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (43,42) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (44,43) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (45,44)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (46,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (47,46)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (48,47)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (49,48)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (50,49)






---Mathematics

INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (51,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (52,51)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (53,52) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (54,53) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (55,54)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (56,55)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (57,56)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (58,57)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (59,78)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (60,79)









-- Psychology 

INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (61,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (62,61)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (63,62) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (64,63) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (65,64)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (66,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (67,66)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (68,67)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (69,68)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (70,69)




---School Of Business
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (71,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (72,71)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (73,NULL) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (74,73) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (75,74)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (76,75)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (77,76)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (78,77)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (79,78)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (80,79)



--Grad Majors

INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' M.S .  Data Analytics ' , 1) 
INSERT INTO [BryantDB].[dbo].[Major] VALUES  ( ' M.S. in Accounting ' , 8  )









--MajorReq


---DatAnlahtics
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 17 , 81) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 17 , 82 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 17, 83) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  (  17, 84 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 17 , 85 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 17 , 86) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 17, 87) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 17 , 88 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 17 ,89 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 17 , 90) 


---accounting
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 18 , 91) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 18 , 92 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 18, 93) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  (  18, 94 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 18 , 95 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 18 , 96) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 18, 97) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 18 , 98 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 18 ,99 ) 
INSERT INTO [BryantDB].[dbo].[MajorRequirements] VALUES  ( 18 , 100) 



--MajorPre-Req

----DataAnalytics
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (81,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (82,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (83,82) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (84,83) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (85,84)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (86,85)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (87,86)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (88,87) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (89,88) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (90 ,89)





--Accounting

INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (91,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (92,NULL)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (93,92) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (94,93) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (95,94)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (96,95)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (97,96)
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (98,97) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (99,98) 
INSERT INTO [BryantDB].[dbo].[MajorPreRequisite] VALUES  (100 ,99)











