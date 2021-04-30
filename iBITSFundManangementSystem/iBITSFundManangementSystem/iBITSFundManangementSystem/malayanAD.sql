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
	announcementDesc VARCHAR(300) NOT NULL,

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

insert into course_tbl values
('BSIT'),
('DICT'),
('DCET');

insert into admin_tbl values
('admin',123);

--select * FROM student_tbl where StudentID = '';
--ALTER TABLE student_tbl UPDATE 