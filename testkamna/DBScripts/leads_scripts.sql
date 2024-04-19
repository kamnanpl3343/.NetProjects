-- Table for storing leads
CREATE TABLE leads (
lead_id INT not null PRIMARY KEY identity(1,1),
    contact_name VARCHAR(100),
    address VARCHAR(100),
    phone VARCHAR(20),
    location VARCHAR(50),
    company_name VARCHAR(100),
    interest VARCHAR(50),
    flag VARCHAR(20),
    remark NVARCHAR(MAX),
    user_assignee VARCHAR(50),
    status VARCHAR(20),
    created_date DATE,
    CompanyId Int Not NUll
);

-- Table for storing follow-up details
CREATE TABLE follow_ups (
    follow_up_id INT not null PRIMARY KEY identity(1,1),
    lead_id int,
    follow_up_date DATE,
    notes NVARCHAR(MAX),
    FOREIGN KEY (lead_id) REFERENCES leads (lead_id)   
);

-- Table for storing comment details
CREATE TABLE comments (
  comment_id INT not null PRIMARY KEY identity(1,1),
    lead_id int,
    comment_date DATE,
    comment_text NVARCHAR(MAX),
    FOREIGN KEY (lead_id) REFERENCES leads (lead_id)
);


-- Alter tables 
Alter table leads add Email varchar(50),
    CreatedBy varchar(50)

    -- Log table


Alter table follow_ups add CreatedBy varchar(50),
    CreatedDate datetime

    
Alter table comments add CreatedBy varchar(50),
    CreatedDate datetime

    
Alter table logs add CreatedBy varchar(50),
    CreatedDate datetime
