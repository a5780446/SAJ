USE [pup]
GO
/****** Object:  Table [dbo].[a]    Script Date: 2022/5/2 下午 09:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[a](
	[id] [nvarchar](50) NOT NULL,
	[pnum] [nvarchar](50) NULL,
	[pname] [nvarchar](50) NOT NULL,
	[thin] [nvarchar](50) NULL,
	[fomat] [nvarchar](50) NULL,
	[qty] [float] NOT NULL,
	[price] [float] NULL,
	[date] [nvarchar](50) NULL,
	[unit] [nvarchar](50) NULL,
	[mark] [nvarchar](50) NULL,
	[total] [float] NULL,
	[remark] [nvarchar](max) NULL,
	[state] [nvarchar](50) NULL,
	[class] [nvarchar](50) NULL,
	[ct] [nvarchar](50) NULL,
	[vname] [nvarchar](50) NULL,
	[realdate] [date] NULL,
	[claas] [nvarchar](50) NULL,
 CONSTRAINT [PK_a] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[b]    Script Date: 2022/5/2 下午 09:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[b](
	[log_id] [nvarchar](50) NOT NULL,
	[indate] [nvarchar](50) NULL,
	[inqty] [float] NULL,
	[inprice] [float] NULL,
	[leftqty] [float] NULL,
	[intotal] [float] NULL,
	[informat] [nvarchar](50) NULL,
	[num] [int] IDENTITY(1,1) NOT NULL,
	[inmark] [nvarchar](50) NULL,
 CONSTRAINT [PK_b] PRIMARY KEY CLUSTERED 
(
	[num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[a] ADD  CONSTRAINT [DF_a_mark]  DEFAULT (N'未核准') FOR [mark]
GO
ALTER TABLE [dbo].[a] ADD  CONSTRAINT [DF_a_state]  DEFAULT (N'未結案') FOR [state]
GO
ALTER TABLE [dbo].[a] ADD  CONSTRAINT [DF_a_realdate]  DEFAULT (getdate()) FOR [realdate]
GO
