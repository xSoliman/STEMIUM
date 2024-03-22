CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Email NVARCHAR(255) UNIQUE,
    Password NVARCHAR(255),
    Name NVARCHAR(100),
    Age INT CHECK (Age BETWEEN 5 AND 100),
    Educational_level NVARCHAR(20) CHECK (Educational_level IN ('Primary', 'Middle', 'Secondary', 'University')),
    College NVARCHAR(100),
    Department NVARCHAR(100),
    Division NVARCHAR(100),
    Government NVARCHAR(100),
    Specialization_subject NVARCHAR(50) CHECK (Specialization_subject IN ('Chemistry', 'Physics', 'Math', 'English')),
    Workplace NVARCHAR(100),
    Type NVARCHAR(20) CHECK (Type IN ('Admin', 'Teacher', 'Student', 'Parent'))
);

CREATE TABLE Feedback (
    Id INT PRIMARY KEY,
    Timestamp DATETIME,
    User_ID INT,
    Feedback_content NVARCHAR(MAX),
    Rate INT CHECK (Rate BETWEEN 1 AND 5),
    FOREIGN KEY (User_ID) REFERENCES Users(Id)
);
