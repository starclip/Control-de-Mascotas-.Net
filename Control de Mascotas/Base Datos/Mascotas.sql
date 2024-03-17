/*==============================================================*/
/* Database name:  MSC                                          */
/* DBMS name:      SAP SQL Anywhere 17                          */
/* Created on:     7/1/2024 15:52:46                            */
/*==============================================================*/

/* Elimina la base de datos */
drop database if exists MSC;
GO

/*==============================================================*/
/* Database: MSC                                                */
/*==============================================================*/
create database MSC;
GO

USE MSC;
GO

/*==============================================================*/
/* Schema: PER                                                */
/*==============================================================*/
create schema PER;
GO

/*==============================================================*/
/* Schema: ANM                                                */
/*==============================================================*/
create schema ANM;
GO

/*==============================================================*/
/* Schema: CFG                                                */
/*==============================================================*/
create schema CFG;
GO

/*==============================================================*/
/* Schema: CTS                                                */
/*==============================================================*/
create schema CTS;
GO

/*==============================================================*/
/* Schema: SIS                                                */
/*==============================================================*/
create schema SIS;
GO

/*==============================================================*/
/* Schema: TMP                                                */
/*==============================================================*/
create schema TMP;
GO

/*==============================================================*/
/* Table: ADMINISTRADOR                                         */
/*==============================================================*/
create table PER.ADMINISTRADOR 
(
   IDADMINISTRADOR      bigint                         not null IDENTITY,
   IDESTADO             bigint                         not null,
   IDPERSONA            bigint                         not null,
   IDPERSONACREACION    bigint                         null,
   IDPERSONAMODIFICACION bigint                         null,
   USUARIO              varchar(100)                   not null,
   CONTRASENA           varchar(512)                   not null,
   FECHACREACION        datetime                       not null,
   FECHAMODIFICACION    datetime                       not null,
   CAMBIOS              rowversion                     not null
);

alter table PER.ADMINISTRADOR
   add constraint PK_ADMINISTRADOR primary key clustered (IDADMINISTRADOR);

/*==============================================================*/
/* Table: ANIMAL                                                */
/*==============================================================*/
create table ANM.ANIMAL 
(
   IDANIMAL             bigint                         not null IDENTITY,
   CODIGO               varchar(50)                    not null,
   NOMBRE               varchar(255)                   not null,
   CAMBIOS              rowversion                     not null
);


alter table ANM.ANIMAL
   add constraint PK_ANIMAL primary key clustered (IDANIMAL);

/*==============================================================*/
/* Table: CANTON                                                */
/*==============================================================*/
create table CFG.CANTON 
(
   IDCANTON             bigint                         not null IDENTITY,
   IDPROVINCIA          bigint                         null,
   CODIGO               varchar(50)                    not null,
   NOMBRE               varchar(255)                   not null,
   CAMBIOS              rowversion                     not null
);


alter table CFG.CANTON
   add constraint PK_CANTON primary key clustered (IDCANTON);

/*==============================================================*/
/* Table: CATALOGO                                              */
/*==============================================================*/
create table SIS.CATALOGO 
(
   IDCATALOGO           bigint                         not null IDENTITY,
   CODIGO               varchar(50)                    not null,
   NOMBRE               varchar(255)                   not null,
   CAMBIOS              rowversion                     not null
);


alter table SIS.CATALOGO
   add constraint PK_CATALOGO primary key clustered (IDCATALOGO);

/*==============================================================*/
/* Table: CATALOGOVALOR                                         */
/*==============================================================*/
create table SIS.CATALOGOVALOR 
(
   IDCATALOGOVALOR      bigint                         not null IDENTITY,
   IDCATALOGO           bigint                         null,
   CODIGO               varchar(50)                    not null,
   NOMBRE               varchar(255)                   not null,
   CAMBIOS              rowversion                     not null
);


alter table SIS.CATALOGOVALOR
   add constraint PK_CATALOGOVALOR primary key clustered (IDCATALOGOVALOR);

/*==============================================================*/
/* Table: CITA                                                  */
/*==============================================================*/
create table CTS.CITA 
(
   IDCITA               bigint                         not null IDENTITY,
   IDCLIENTE            bigint                         not null,
   IDVETERINARIO        bigint                         not null,
   IDESTADO             bigint                         not null,
   IDMASCOTA            bigint                         not null,
   IDHORA               bigint						   not null,
   IDPERSONACREACION    bigint                         not null,
   IDPERSONAMODIFICACION bigint                         not null,
   FECHA                date                           not null,
   PESOMASCOTA          decimal(10, 2)                 null,
   OBSERVACIONES        varchar(2000)                  null,
   EDADMESES            int                            null,
   EDADANIOS            int                            null,
   FECHACREACION        datetime                       not null,
   FECHAMODIFICACION    datetime                       not null,
   CAMBIOS              rowversion                     not null
);

alter table CTS.CITA
   add constraint PK_CITA primary key clustered (IDCITA);

/*==============================================================*/
/* Table: CITATRATAMIENTO                                       */
/*==============================================================*/
create table CTS.CITATRATAMIENTO 
(
   IDCITATRATAMIENTO    bigint                         not null IDENTITY,
   IDCITA               bigint                         not null,
   IDTRATAMIENTO        bigint                         not null,
   CANTIDAD             int                            not null,
   FECHA                datetime                       not null,
   CAMBIOS              rowversion                     not null
);

alter table CTS.CITATRATAMIENTO
   add constraint PK_CITATRATAMIENTO primary key clustered (IDCITATRATAMIENTO);

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table PER.CLIENTE 
(
   IDCLIENTE            bigint                         not null IDENTITY,
   IDDISTRITO           bigint                         not null,
   IDPERSONA            bigint                         not null,
   IDESTADO             bigint                         not null,
   IDSEXO               bigint                         not null,
   IDPERSONACREACION    bigint                         not null,
   IDPERSONAMODIFICACION bigint                         not null,
   DIRECCION            varchar(255)                   null,
   FECHACREACION        datetime                       not null,
   FECHAMODIFICACION    datetime                       not null,
   CAMBIOS              rowversion                     not null
);

alter table PER.CLIENTE
   add constraint PK_CLIENTE primary key clustered (IDCLIENTE);

/*==============================================================*/
/* Table: DISTRITO                                              */
/*==============================================================*/
create table CFG.DISTRITO 
(
   IDDISTRITO           bigint                         not null IDENTITY,
   IDCANTON             bigint                         null,
   CODIGO               varchar(50)                    not null,
   NOMBRE               varchar(255)                   not null,
   CAMBIOS              rowversion                     not null
);

alter table CFG.DISTRITO
   add constraint PK_DISTRITO primary key clustered (IDDISTRITO);

/*==============================================================*/
/* Table: MASCOTA                                               */
/*==============================================================*/
create table ANM.MASCOTA 
(
   IDMASCOTA            bigint                         not null IDENTITY,
   IDANIMAL             bigint                         not null,
   IDCLIENTE            bigint                         not null,
   IDSEXO               bigint                         not null,
   IDESTADO             bigint                         not null,
   IDPERSONACREACION    bigint                         not null,
   IDPERSONAMODIFICACION bigint                         not null,
   FECHANACIMIENTO      datetime                       not null,
   NOMBRE				varchar(255)				   not null,
   RAZA                 varchar(255)                   null,
   COLOR                varchar(255)                   null,
   DESCRIPCION          varchar(1024)                  null,
   INDICADORCASTRADO    bit                            not null,
   FECHACASTRACION      datetime                       null,
   FOTO                 varbinary(max)                 null,
   FECHACREACION        datetime                       not null,
   FECHAMODIFICACION    datetime                       not null,
   CAMBIOS              rowversion                     not null
);

alter table ANM.MASCOTA
   add constraint PK_MASCOTA primary key clustered (IDMASCOTA);

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table PER.PERSONA 
(
   IDPERSONA            bigint                         not null IDENTITY,
   CEDULA               varchar(50)                    not null,
   PRIMERNOMBRE         varchar(255)                   not null,
   SEGUNDONOMBRE        varchar(255)                   null,
   PRIMERAPELLIDO       varchar(255)                   not null,
   SEGUNDOAPELLIDO      varchar(255)                   not null,
   FECHANACIMIENTO      datetime                       not null,
   TELEFONO             varchar(50)                    null,
   CORREO               varchar(255)                   null,
   CAMBIOS              rowversion                     not null
);

alter table PER.PERSONA
   add constraint PK_PERSONA primary key clustered (IDPERSONA);

/*==============================================================*/
/* Table: PROVINCIA                                             */
/*==============================================================*/
create table CFG.PROVINCIA 
(
   IDPROVINCIA          bigint                         not null IDENTITY,
   CODIGO               varchar(50)                    not null,
   NOMBRE               varchar(255)                   not null,
   CAMBIOS              rowversion                     not null
);

alter table CFG.PROVINCIA
   add constraint PK_PROVINCIA primary key clustered (IDPROVINCIA);

/*==============================================================*/
/* Table: TRATAMIENTO                                           */
/*==============================================================*/
create table CFG.TRATAMIENTO 
(
   IDTRATAMIENTO        bigint                         not null IDENTITY,
   IDESTADO             bigint                         not null,
   IDPERSONACREACION    bigint                         not null,
   IDPERSONAMODIFICACION bigint                         not null,
   CODIGO               varchar(50)                    not null,
   NOMBRE               varchar(255)                   not null,
   DESCRIPCION          varchar(1024)                  null,
   EFECTOS              varchar(2000)                  null,
   TARIFA               decimal(10,4)                  null,
   IMAGEN               varbinary(max)                 null,
   FECHACREACION        datetime                       not null,
   FECHAMODIFICACION    datetime                       not null,
   CAMBIOS              rowversion                     not null
);

alter table CFG.TRATAMIENTO
   add constraint PK_TRATAMIENTO primary key clustered (IDTRATAMIENTO);

/*==============================================================*/
/* Table: VETERINARIO                                           */
/*==============================================================*/
create table PER.VETERINARIO 
(
   IDVETERINARIO        bigint                         not null IDENTITY,
   IDPERSONA            bigint                         not null,
   IDESTADO             bigint                         not null,
   IDPERSONACREACION    bigint                         not null,
   IDPERSONAMODIFICACION bigint                         not null,
   USUARIO              varchar(100)                   not null,
   CONTRASENA           varchar(512)                   not null,
   FECHACREACION        datetime                       not null,
   FECHAMODIFICACION    datetime                       not null,
   CAMBIOS              rowversion                     not null
);

alter table PER.VETERINARIO
   add constraint PK_VETERINARIO primary key clustered (IDVETERINARIO);

alter table PER.ADMINISTRADOR
   add constraint FK_ADMINISTRADOR_PERSONA_IDPERSONA foreign key (IDPERSONA)
      references PER.PERSONA (IDPERSONA);

alter table PER.ADMINISTRADOR
   add constraint FK_CATALOGOVALOR_ADMINISTRADOR_IDESTADO foreign key (IDESTADO)
      references SIS.CATALOGOVALOR (IDCATALOGOVALOR);

alter table PER.ADMINISTRADOR
   add constraint FK_PERSONA_ADMINISTRADOR_IDPERSONACREACION foreign key (IDPERSONACREACION)
      references PER.PERSONA (IDPERSONA);

alter table PER.ADMINISTRADOR
   add constraint FK_PERSONA_ADMINISTRADOR_IDPERSONAMODIFICACION foreign key (IDPERSONAMODIFICACION)
      references PER.PERSONA (IDPERSONA);

alter table CFG.CANTON
   add constraint FK_CANTON_PROVINCIA_IDPROVINCIA foreign key (IDPROVINCIA)
      references CFG.PROVINCIA (IDPROVINCIA);

alter table SIS.CATALOGOVALOR
   add constraint FK_CATALOGOVALOR_CATALOGO_IDCATALOGO foreign key (IDCATALOGO)
      references SIS.CATALOGO (IDCATALOGO);

alter table CTS.CITA
   add constraint FK_CATALOGOVALOR_CITA_IDESTADO foreign key (IDESTADO)
      references SIS.CATALOGOVALOR (IDCATALOGOVALOR);

alter table CTS.CITA
   add constraint FK_CATALOGOVALOR_CITA_IDHORA foreign key (IDHORA)
      references SIS.CATALOGOVALOR (IDCATALOGOVALOR);

alter table CTS.CITA
   add constraint FK_CLIENTE_CITA_IDCLIENTE foreign key (IDCLIENTE)
      references PER.CLIENTE (IDCLIENTE);

alter table CTS.CITA
   add constraint FK_MASCOTA_CITA_IDMASCOTA foreign key (IDMASCOTA)
      references ANM.MASCOTA (IDMASCOTA);

alter table CTS.CITA
   add constraint FK_PERSONA_CITA_IDPERSONACREACION foreign key (IDPERSONACREACION)
      references PER.PERSONA (IDPERSONA);

alter table CTS.CITA
   add constraint FK_PERSONA_CITA_IDPERSONAMODIFICACION foreign key (IDPERSONAMODIFICACION)
      references PER.PERSONA (IDPERSONA);

alter table CTS.CITA
   add constraint FK_VETERINARIO_CITA_IDVETERINARIO foreign key (IDVETERINARIO)
      references PER.VETERINARIO (IDVETERINARIO);

alter table CTS.CITATRATAMIENTO
   add constraint FK_CITA_CITATRATAMIENTO_IDCITA foreign key (IDCITA)
      references CTS.CITA (IDCITA);

alter table CTS.CITATRATAMIENTO
   add constraint FK_TRATAMIENTO_CITATRATAMIENTO_IDTRATAMIENTO foreign key (IDTRATAMIENTO)
      references CFG.TRATAMIENTO (IDTRATAMIENTO);

alter table PER.CLIENTE
   add constraint FK_CATALOGOVALOR_CLIENTE_IDESTADO foreign key (IDESTADO)
      references SIS.CATALOGOVALOR (IDCATALOGOVALOR);

alter table PER.CLIENTE
   add constraint FK_CATALOGOVALOR_CLIENTE_IDSEXO foreign key (IDSEXO)
      references SIS.CATALOGOVALOR (IDCATALOGOVALOR);

alter table PER.CLIENTE
   add constraint FK_DISTRITO_CLIENTE_IDDISTRITO foreign key (IDDISTRITO)
      references CFG.DISTRITO (IDDISTRITO);

alter table PER.CLIENTE
   add constraint FK_PERSONA_CLIENTE_IDPERSONA foreign key (IDPERSONA)
      references PER.PERSONA (IDPERSONA);

alter table PER.CLIENTE
   add constraint FK_CLIENTE_FK_PERSON_PERSONA foreign key (IDPERSONACREACION)
      references PER.PERSONA (IDPERSONA);

alter table PER.CLIENTE
   add constraint FK_PERSONA_CLIENTE_IDPERSONAMODIFICACION foreign key (IDPERSONAMODIFICACION)
      references PER.PERSONA (IDPERSONA);

alter table CFG.DISTRITO
   add constraint FK_CANTON_DISTRITO_IDCANTON foreign key (IDCANTON)
      references CFG.CANTON (IDCANTON);

alter table ANM.MASCOTA
   add constraint FK_ANIMAL_MASCOTA_IDANIMAL foreign key (IDANIMAL)
      references ANM.ANIMAL (IDANIMAL);

alter table ANM.MASCOTA
   add constraint FK_CATALOGOVALOR_MASCOTA_IDESTADO foreign key (IDESTADO)
      references SIS.CATALOGOVALOR (IDCATALOGOVALOR);

alter table ANM.MASCOTA
   add constraint FK_CATALOGOVALOR_MASCOTA_IDSEXO foreign key (IDSEXO)
      references SIS.CATALOGOVALOR (IDCATALOGOVALOR);

alter table ANM.MASCOTA
   add constraint FK_CLIENTE_MASCOTA_IDCLIENTE foreign key (IDCLIENTE)
      references PER.CLIENTE (IDCLIENTE);

alter table ANM.MASCOTA
   add constraint FK_PERSONA_MASCOTA_IDPERSONACREACION foreign key (IDPERSONACREACION)
      references PER.PERSONA (IDPERSONA);

alter table ANM.MASCOTA
   add constraint FK_PERSONA_MASCOTA_IDPERSONAMODIFICACION foreign key (IDPERSONAMODIFICACION)
      references PER.PERSONA (IDPERSONA);

alter table CFG.TRATAMIENTO
   add constraint FK_CATALOGOVALOR_TRATAMIENTO_IDESTADO foreign key (IDESTADO)
      references SIS.CATALOGOVALOR (IDCATALOGOVALOR);

alter table CFG.TRATAMIENTO
   add constraint FK_PERSONA_TRATAMIENTO_IDPERSONACREACION foreign key (IDPERSONACREACION)
      references PER.PERSONA (IDPERSONA);

alter table CFG.TRATAMIENTO
   add constraint FK_PERSONA_TRATAMIENTO_IDPERSONAMODIFICACION foreign key (IDPERSONAMODIFICACION)
      references PER.PERSONA (IDPERSONA);

alter table PER.VETERINARIO
   add constraint FK_CATALOGOVALOR_VETERINARIO_IDESTADO foreign key (IDESTADO)
      references SIS.CATALOGOVALOR (IDCATALOGOVALOR);

alter table PER.VETERINARIO
   add constraint FK_VETERINA_FK_PERSON_PERSONA foreign key (IDPERSONA)
      references PER.PERSONA (IDPERSONA);

alter table PER.VETERINARIO
   add constraint FK_PERSONA_VETERINARIO_IDPERSONACREACION foreign key (IDPERSONACREACION)
      references PER.PERSONA (IDPERSONA);

alter table PER.VETERINARIO
   add constraint FK_PERSONA_VETERINARIO_IDPERSONAMODIFICACION foreign key (IDPERSONAMODIFICACION)
      references PER.PERSONA (IDPERSONA);

/*==============================================================*/
/* Table: Provincia                                           */
/*==============================================================*/
create table TMP.PROVINCIA 
(
   CODIGO            INT                         not null,
   NOMBRE             VARCHAR(250)                         not null
);

/*==============================================================*/
/* Table: Canton                                           */
/*==============================================================*/
create table TMP.CANTON 
(
   CODIGO            INT                         not null,
   PROVINCIA             INT                         not null,
   NOMBRE             VARCHAR(250)                         not null
);

/*==============================================================*/
/* Table: Distrito                                           */
/*==============================================================*/
create table TMP.DISTRITO 
(
   CODIGO            INT                         not null,
   CANTON             INT                         not null,
   NOMBRE             VARCHAR(250)                         not null
);