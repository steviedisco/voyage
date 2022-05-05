USE [VoyageCare]
GO

/****** Object:  Table [dbo].[CareQualification]    Script Date: 04/05/2022 16:43:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CareQualification](
	[CareQualificationID] [int] IDENTITY(1,1) NOT NULL,
	[CareHomeStaffID] [int] NOT NULL,
	[Type] [varchar](255) NOT NULL,
	[Grade] [varchar](50) NOT NULL,
	[AttainmentDate] [date] NULL,
 CONSTRAINT [PK_CareQualification] PRIMARY KEY CLUSTERED 
(
	[CareQualificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CareQualification]  WITH CHECK ADD  CONSTRAINT [FK_CareQualification_CareHomeStaff] FOREIGN KEY([CareHomeStaffID])
REFERENCES [dbo].[CareHomeStaff] ([CareHomeStaffID])
GO

ALTER TABLE [dbo].[CareQualification] CHECK CONSTRAINT [FK_CareQualification_CareHomeStaff]
GO


