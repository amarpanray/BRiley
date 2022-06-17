USE [BRiley]
GO

/****** Object: Table [dbo].[Transaction] Script Date: 6/17/2022 5:21:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transaction] (
    [TransactionID]      INT           IDENTITY (1, 1) NOT NULL,
    [FromAccount]        VARCHAR (50)  NULL,
    [ToAccount]          VARCHAR (50)  NULL,
    [TransactionTime]    DATETIME2 (7) NULL,
    [AmountDebited]      MONEY         NULL,
    [FromAccountBalance] MONEY         NULL,
    [ToAccountBalance]   MONEY         NULL,

    PRIMARY KEY ([TransactionID]) 
);


