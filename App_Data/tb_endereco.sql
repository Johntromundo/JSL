USE [BDJSL]
GO

/****** Object:  Table [dbo].[Endereco]    Script Date: 01/07/2021 08:41:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Endereco](
	[id_end] [int] IDENTITY(1,1) NOT NULL,
	[logradouro] [varchar](50) NOT NULL,
	[bairro] [varchar](50) NOT NULL,
	[uf] [varchar](2) NOT NULL,
	[cep] [varchar](20) NOT NULL,
	[cidade] [varchar](50) NOT NULL,
	[complemento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[id_end] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

