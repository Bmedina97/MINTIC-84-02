-- -----------------------------------------------------
-- Schema INVENTARIO_LLANTAS
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Table proveedor
-- -----------------------------------------------------
CREATE TABLE  proveedor (
  pro_id [int] IDENTITY(1,1) NOT NULL,
  pro_nit VARCHAR(45) NOT NULL,
  pro_nombre VARCHAR(70) NOT NULL,
  pro_direccion VARCHAR(70) NOT NULL,
  pro_telefono VARCHAR(45) NOT NULL,
  pro_email VARCHAR(100) NOT NULL,
  pro_vigente TINYINT NOT NULL DEFAULT 1,
  PRIMARY KEY (pro_id))
;


-- -----------------------------------------------------
-- Table remision
-- -----------------------------------------------------
CREATE TABLE  remision (
  rem_id [int] IDENTITY(1,1) NOT NULL,
  rem_consecutivo VARCHAR(45) NOT NULL,
  rem_fecha DATETIME NOT NULL,
  rem_vigente TINYINT NOT NULL DEFAULT 1,
  rem_observaciones TEXT NULL,
  rem_proveedor INT NOT NULL,
  PRIMARY KEY (rem_id),
  CONSTRAINT proveedor_FK_remision
    FOREIGN KEY (rem_proveedor)
    REFERENCES proveedor (pro_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;

CREATE INDEX proveedor_FK_remision_idx ON remision (rem_proveedor ASC) ;


-- -----------------------------------------------------
-- Table dimension
-- -----------------------------------------------------
CREATE TABLE  dimension (
  dim_id [int] IDENTITY(1,1) NOT NULL,
  dim_nombre VARCHAR(45) NOT NULL,
  PRIMARY KEY (dim_id))
;


-- -----------------------------------------------------
-- Table banda
-- -----------------------------------------------------
CREATE TABLE  banda (
  ban_id [int] IDENTITY(1,1) NOT NULL,
  ban_nombre VARCHAR(45) NOT NULL,
  PRIMARY KEY (ban_id))
;


-- -----------------------------------------------------
-- Table llanta
-- -----------------------------------------------------
CREATE TABLE  llanta (
  llan_id [int] IDENTITY(1,1) NOT NULL,
  llan_codigo VARCHAR(45) NOT NULL,
  llan_dot VARCHAR(45) NOT NULL,
  llan_marca VARCHAR(45) NOT NULL,
  llan_diseno_original VARCHAR(45) NOT NULL,
  llan_diseno_reencauche VARCHAR(45) NULL,
  llan_vigente TINYINT NOT NULL DEFAULT 1,
  llan_dimension INT NOT NULL,
  llan_banda INT NOT NULL,
  PRIMARY KEY (llan_id),
  CONSTRAINT dimension_FK_llanta
    FOREIGN KEY (llan_dimension)
    REFERENCES dimension (dim_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT banda_FK_llanta
    FOREIGN KEY (llan_banda)
    REFERENCES banda (ban_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;

CREATE INDEX dimension_FK_llanta_idx ON llanta (llan_dimension ASC) ;

CREATE INDEX banda_FK_llanta_idx ON llanta (llan_banda ASC) ;


-- -----------------------------------------------------
-- Table vida
-- -----------------------------------------------------
CREATE TABLE  vida (
  vid_id [int] IDENTITY(1,1) NOT NULL,
  vid_nombre VARCHAR(45) NOT NULL,
  PRIMARY KEY (vid_id))
;


-- -----------------------------------------------------
-- Table remision_llanta
-- -----------------------------------------------------
CREATE TABLE  remision_llanta (
  remllan_remision INT NOT NULL,
  remllan_llanta INT NOT NULL,
  remllan_cantidad INT NOT NULL,
  remllan_vigente TINYINT NOT NULL DEFAULT 1,
  remllan_vida INT NOT NULL,
  PRIMARY KEY (remllan_remision, remllan_llanta),
  CONSTRAINT remision_FK_remision_llanta
    FOREIGN KEY (remllan_remision)
    REFERENCES remision (rem_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT llanta_FK_remision_llanta
    FOREIGN KEY (remllan_llanta)
    REFERENCES llanta (llan_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT vida_FK_remision_llanta
    FOREIGN KEY (remllan_vida)
    REFERENCES vida (vid_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;

CREATE INDEX llanta_FK_remision_llanta_idx ON remision_llanta (remllan_llanta ASC) ;

CREATE INDEX vida_FK_remision_llanta_idx ON remision_llanta (remllan_vida ASC) ;


-- -----------------------------------------------------
-- Table tipo
-- -----------------------------------------------------
CREATE TABLE  tipo (
  tipo_id [int] IDENTITY(1,1) NOT NULL,
  tipo_nombre VARCHAR(45) NOT NULL,
  PRIMARY KEY (tipo_id))
;


-- -----------------------------------------------------
-- Table equipo
-- -----------------------------------------------------
CREATE TABLE  equipo (
  equi_id [int] IDENTITY(1,1) NOT NULL,
  equi_placa VARCHAR(45) NOT NULL,
  equi_vigente TINYINT NOT NULL DEFAULT 1,
  equi_tipo INT NOT NULL,
  PRIMARY KEY (equi_id),
  CONSTRAINT tipo_FK_equipo
    FOREIGN KEY (equi_tipo)
    REFERENCES tipo (tipo_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;

CREATE INDEX tipo_FK_equipo_idx ON equipo (equi_tipo ASC) ;


-- -----------------------------------------------------
-- Table prestador
-- -----------------------------------------------------
CREATE TABLE  prestador (
  pres_id [int] IDENTITY(1,1) NOT NULL,
  pres_nit VARCHAR(45) NOT NULL,
  pres_nombre VARCHAR(70) NOT NULL,
  pres_direccion VARCHAR(70) NOT NULL,
  pres_telefono VARCHAR(45) NOT NULL,
  pres_email VARCHAR(100) NOT NULL,
  pres_vigente TINYINT NOT NULL DEFAULT 1,
  PRIMARY KEY (pres_id))
;


-- -----------------------------------------------------
-- Table conductor
-- -----------------------------------------------------
CREATE TABLE  conductor (
  con_id [int] IDENTITY(1,1) NOT NULL,
  con_documento VARCHAR(45) NOT NULL,
  con_nombre VARCHAR(100) NOT NULL,
  con_vigente TINYINT NOT NULL DEFAULT 1,
  PRIMARY KEY (con_id))
;


-- -----------------------------------------------------
-- Table posicion
-- -----------------------------------------------------
CREATE TABLE  posicion (
  pos_id [int] IDENTITY(1,1) NOT NULL,
  pos_numero INT NOT NULL,
  PRIMARY KEY (pos_id))
;


-- -----------------------------------------------------
-- Table ot
-- -----------------------------------------------------
CREATE TABLE  ot (
  ot_id [int] IDENTITY(1,1) NOT NULL,
  ot_consecutivo VARCHAR(45) NOT NULL,
  ot_fecha DATETIME NOT NULL,
  ot_kilometraje VARCHAR(45) NOT NULL,
  ot_descripcion TEXT NOT NULL,
  ot_vigente TINYINT NOT NULL DEFAULT 1,
  ot_posicion INT NOT NULL,
  ot_conductor INT NOT NULL,
  ot_equipo INT NOT NULL,
  ot_prestador INT NOT NULL,
  PRIMARY KEY (ot_id),
  CONSTRAINT conductor_FK_ot
    FOREIGN KEY (ot_conductor)
    REFERENCES conductor (con_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT equipo_FK_ot
    FOREIGN KEY (ot_equipo)
    REFERENCES equipo (equi_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT prestador_FK_ot
    FOREIGN KEY (ot_prestador)
    REFERENCES prestador (pres_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT posicion_FK_ot
    FOREIGN KEY (ot_posicion)
    REFERENCES posicion (pos_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;

CREATE INDEX conductor_FK_ot_idx ON ot (ot_conductor ASC) ;

CREATE INDEX equipo_FK_ot_idx ON ot (ot_equipo ASC) ;

CREATE INDEX prestador_FK_ot_idx ON ot (ot_prestador ASC) ;

CREATE INDEX posicion_FK_ot_idx ON ot (ot_posicion ASC) ;


-- -----------------------------------------------------
-- Table llanta_ot
-- -----------------------------------------------------
CREATE TABLE  llanta_ot (
  llanot_ot INT NOT NULL,
  llanot_llanta INT NOT NULL,
  llanot_vigente TINYINT NOT NULL DEFAULT 1,
  PRIMARY KEY (llanot_ot, llanot_llanta),
  CONSTRAINT ot_FK_llanta_ot
    FOREIGN KEY (llanot_ot)
    REFERENCES ot (ot_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT llanta_FK_llanta_ot
    FOREIGN KEY (llanot_llanta)
    REFERENCES llanta (llan_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;

CREATE INDEX ot_FK_llanta_ot_idx ON llanta_ot (llanot_ot ASC) ;

CREATE INDEX llanta_FK_llanta_ot_idx ON llanta_ot (llanot_llanta ASC) ;
