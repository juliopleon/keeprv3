CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

ALTER TABLE accounts
ADD
    COLUMN coverImg VARCHAR(255) NOT NULL DEFAULT "https://media.istockphoto.com/id/1141304089/vector/global-network-connection-concept-big-data-visualization-social-network-communication-in-the.jpg?s=612x612&w=0&k=20&c=XoQRixTQExBgu3CKeSzTleQSbasbpBkDs3S3q6BByOM=";