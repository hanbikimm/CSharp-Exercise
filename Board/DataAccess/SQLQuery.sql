USE Board

CREATE TABLE Employee (
	Emp_Seq int IDENTITY PRIMARY KEY
	,Emp_Name varchar(20) NOT NULL
	,Emp_Age int NOT NULL
	,Emp_Address varchar(100) NOT NULL
	,Emp_Phone varchar(13) NOT NULL
	,Emp_Profile varchar(200) NOT NULL
);

INSERT INTO Employee VALUES('김한비', 26, '서울시 마포구', '010-8073-7748', 'D:/')
INSERT INTO Employee VALUES('김한비', 26, '서울시 마포구', '010-8073-7748', 'D:/')

SELECT Emp_Seq, Emp_Name, Emp_Age, Emp_Address, Emp_Phone, Emp_Profile
	FROM Employee;

CREATE TABLE Career (
	Career_Seq int IDENTITY PRIMARY KEY
	,Emp_Seq int FOREIGN KEY REFERENCES Employee(Emp_Seq)
	,From_DT date NOT NULL
	,End_DT date NOT NULL
	,Memo varchar(200)
);