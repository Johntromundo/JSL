USE [BDJSL]
GO

/****** Object:  Table [dbo].[Motorista]    Script Date: 01/07/2021 08:42:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Motorista](
	[id_motorista] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Sobrenome] [varchar](50) NULL,
	[id_end] [int] NULL,
 CONSTRAINT [PK_Motorista] PRIMARY KEY CLUSTERED 
(
	[id_motorista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Motorista]  WITH CHECK ADD  CONSTRAINT [FK_Motorista_Endereco] FOREIGN KEY([id_end])
REFERENCES [dbo].[Endereco] ([id_end])
GO

ALTER TABLE [dbo].[Motorista] CHECK CONSTRAINT [FK_Motorista_Endereco]
GO

