CREATE DATABASE malayan;

USE  malayan;

--CREATE TABLE COURSE TABLE
CREATE TABLE course_tbl(
    course_ID INT NOT NULL IDENTITY(1,1),
	courseName VARCHAR (100) NOT NULL,

	CONSTRAINT pkey_courseID PRIMARY KEY (course_ID)
);


--CREATE TABLE STUDENT INFORMATION
CREATE TABLE student_tbl(
    StudentID  VARCHAR (100) NOT NULL,
	CourseID INT NOT NULL,
    studLname VARCHAR (25) NOT NULL,
    studFname VARCHAR (25) NOT NULL,
    studMname VARCHAR (25) NOT NULL,
    age INT,
    gender VARCHAR (20),
	yearlevel VARCHAR(20),
	CONSTRAINT fkey_course FOREIGN KEY (CourseID) REFERENCES  course_tbl (course_ID),
	CONSTRAINT pkey_StudID PRIMARY KEY (StudentID)
);



--CREATE TABLE MISCELLANEOUS 
CREATE TABLE misc_tbl (
    misc_ID INT NOT NULL IDENTITY (1,1),
    misc_name VARCHAR (100) NOT NULL,
    misc_date VARCHAR (100) NOT NULL,
    misc_duedate VARCHAR (100) NOT NULL,
    misc_amount DECIMAL (19,4),

    CONSTRAINT pkey_mics PRIMARY KEY (misc_ID)   
);



--PAYMENT HISTORY TABLE
CREATE TABLE paymentHistory(
    paymentID INT NOT NULL IDENTITY(1,1),
    misc_ID INT NOT NULL,
    StudentID  VARCHAR (100) NOT NULL,
    misc_status VARCHAR(20),
    misc_datepaid VARCHAR (100) NOT NULL,

    CONSTRAINT fkey_misc FOREIGN KEY (misc_ID) REFERENCES misc_tbl (misc_ID),
    CONSTRAINT fkey_student FOREIGN KEY (StudentID) REFERENCES student_tbl (StudentID)

);


--CREATE TABLE ANNOUNCEMENT 
CREATE TABLE announcement_tbl(
    announcementID INT NOT NULL IDENTITY(1,1),
    announcementDate VARCHAR (100) NOT NULL,
    announcement VARCHAR(300) NOT NULL,

    CONSTRAINT pkey_announcementID PRIMARY KEY (announcementID) 
);


--CREATE TABLE REGISTRATION
CREATE TABLE login_tbl(
    userID INT NOT NULL IDENTITY (1,1),
	StudentID VARCHAR(100) NOT NULL,
    username VARCHAR (100) NOT NULL,
    password VARCHAR (100) NOT NULL,
	CONSTRAINT fkey_StudID FOREIGN KEY (StudentID) REFERENCES  student_tbl (StudentID),
    CONSTRAINT pkey_registerID PRIMARY KEY (userID) 
);

CREATE TABLE admin_tbl(
    adminID int NOT NULL IDENTITY(1,1),
	username VARCHAR (100) NOT NULL,
    password VARCHAR (100) NOT NULL
);

--INSERT INTO MISC.
INSERT INTO misc_tbl VALUES 
('Org Shirt', '','2021-02-23', 250),
('Org Fee', '', '2021-03-15', 200),
('Conribution', '', '2021-03-29', 150);

insert into course_tbl values
('BSIT'),
('DICT'),
('DCET');

insert into student_tbl values
('2018-001-LQ',1,'Irog','Denmark','Obnamia',21,'Male','3'),
('2018-002-LQ',2,'Serdinio','Jennilyn','Ewan',20,'Female','3'),
('2018-003-LQ',1,'Del Espirito Santo','Arllan','Rabe',21,'Male','3');


insert into login_tbl values
('2018-003-LQ','arllan',123);

insert into admin_tbl values
('admin',123);

--INSERT INTO PAYMENT HISTORY
INSERT INTO paymentHistory VALUES
 (1,'2018-001-LQ', 'Paid','2021-02-28'),
 (2, '2018-001-LQ','Paid','2021-03-25'),
 (3,'2018-003-LQ', 'Paid','2021-02-04');


 select misc_status,  count(misc_status) 'Number of Paid', Grouping (misc_status) as 'Name' from paymentHistory where misc_status = 'Paid' GROUP BY misc_ID

GO  

SELECT 
	misc_tbl.misc_name,student_tbl.studFname, paymentHistory.misc_status
FROM
	(((student_tbl INNER JOIN paymentHistory ON student_tbl.studentID = paymentHistory.studentID INNER JOIN misc_tbl  ON misc_tbl.misc_ID = paymentHistory.misc_ID ))) where misc_status = 'Paid' order by misc_datepaid desc;



  SELECT 
	login_tbl.studentID, misc_tbl.misc_name,misc_tbl.misc_amount, student_tbl.studFname , paymentHistory.misc_status, paymentHistory.misc_datepaid
	
FROM
	((login_tbl INNER JOIN student_tbl ON login_tbl.StudentID = student_tbl.StudentID  INNER JOIN  paymentHistory ON paymentHistory.StudentID = student_tbl.StudentID INNER JOIN misc_tbl ON paymentHistory.misc_ID = misc_tbl.misc_ID)) WHERE username = 'arllan'
	
	use master

	select * from (login_tbl INNER JOIN student_tbl ON login_tbl.StudentID = student_tbl.StudentID) where username = 'aran_desu'

    SELECT * FROM student_tbl;
    DELETE  FROM student_tbl where StudentID = '20219-00293-LQ-0';

INSERT INTO login_tbl VALUES ('2018-004-LQ','aran','123');