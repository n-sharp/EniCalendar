create table VacationEntry
(
    Id raw(16) not null,
    DateFrom Date not null,
    DateTo Date not null,
    Title VARCHAR2(255),
    Comments VARCHAR2(4000),
    VacationType NUMBER(10),
    ApprovalStatus NUMBER(10)
);

create table HolidayEntry
(
    Id raw(16) not null,
    DateFrom Date not null,
    DateTo Date not null,
    Title VARCHAR2(255)
);

create table Employee
(
    Username VARCHAR(255) not null,
    FirstName VARCHAR(255),
    LastName VARCHAR(255)
);