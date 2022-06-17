USE [BRiley]
GO

/****** Object: Table [dbo].[Account_Transaction] Script Date: 6/17/2022 5:05:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountTransaction] (
    [AccountTransactionID] INT IDENTITY (1, 1) NOT NULL,
    [AccountID]             INT NULL,
    [TransactionID]         INT NULL, 
	
	 
	    PRIMARY KEY (  [AccountTransactionID]), 
	
	    CONSTRAINT FK_AccountTransactions FOREIGN KEY (AccountID)
        REFERENCES Account (AccountID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,

		CONSTRAINT FK_TransactionAccount FOREIGN KEY (TransactionID)
        REFERENCES [Transaction] (TransactionID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


