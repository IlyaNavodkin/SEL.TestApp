CREATE TABLE Departments
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) UNIQUE,
    ParentDepartmentId INT
);

CREATE TABLE Workers
(
    Id INT PRIMARY KEY IDENTITY,
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    FirstName NVARCHAR(255),
    MidName NVARCHAR(255),
    LastName NVARCHAR(255),
    PersonnelNumber INT UNIQUE
);

INSERT INTO Departments (Name, ParentDepartmentId)
VALUES
    ('����� �� ������������ ��������', NULL),
    ('����� ������', 1),
    ('����� ������� ������', 2),
    ('����� ��������� ������', 2),
    ('����� ���������', 1),
    ('�����', 5),
    ('����� ��������', 5),
    ('���������������� �����', NULL),
    ('���������� �����', 8),
    ('����� �������� ��������', 8),
    ('����� �������', 8),
    ('�����������', NULL);

INSERT INTO Workers (DepartmentId, FirstName, MidName, LastName, PersonnelNumber)
VALUES
    (1, '����', '��������', '������', 1001),
    (2, '�������', '����������', '�������', 2001),
    (3, '�����', '������������', '�������', 3001),
    (3, '���������', '����������', '��������', 3002),
    (4, '�������', '���������', '������', 4001),
    (4, '����', '�������������', '��������', 4002),
    (5, '������', '����������', '������', 5001),
    (6, '�����', '�������������', '�������', 6001),
    (6, '�����', '��������', '�������', 6002),
    (7, '������', '���������', '��������', 7001),
    (7, '�����', '����������', '��������', 7002),
    (7, '�����', '����������', '�������', 7003),
    (7, '������', '��������', '��������', 7004),
    (7, '�����', '�������������', '��������', 7005),
    (8, '������', '����������', '��������', 8001),
    (9, '��������', '��������', '������', 9001),
    (9, '�������', '�������������', '��������', 9002),
    (9, '�����', '����������', '������', 9003),
    (9, '�����', '����������', '��������', 9004),
    (10, '�����', '������������', '�������', 10001),
    (10, '���������', '����������', '�������', 10002),
    (11, '����', '�������������', '�������', 11001),
    (12, '������', '���������', '������', 12001),
    (12, '���������', '����������', '��������', 12002);