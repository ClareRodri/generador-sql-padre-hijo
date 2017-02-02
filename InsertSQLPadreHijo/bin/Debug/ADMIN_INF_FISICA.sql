INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_INFRAESTRUCTURA','Visualizar opción administración de infraestructura',NULL,'Opción del menu para visualizar la administración de infraestructura', 'Activo');
COMMIT;

INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_INF_FISICA','Visualizar opción infraestructura fisica en administración de infraestructura',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_INFRAESTRUCTURA'),'Permiso para consultar tipos de habitaciones', 'Activo');
COMMIT; 

INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_REA_ESTCAMAS','Consultar estados de cama',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_INF_FISICA'),'Permiso para consultar estados de cama', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_REA_THABITACIONES','Consultar tipos de habitaciones',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_INF_FISICA'),'Listado de tipos de habitaciones registrados', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_REA_INFRUORG','Consultar infraestructura física por unidad organizacional',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_INF_FISICA'),'Permiso para consultar infraestructura física por unidad organizacional', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_REA_ADMPISO','Consultar administración de piso',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_INFRUORG'),'Permiso para consultar la administración de piso en una unidad organizacional', 'Activo');
COMMIT; 

INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_CRE_THABITACIONES','Crear tipos de habitaciones',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_THABITACIONES'),'Permiso para crear tipos de habitaciones', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_UPD_THABITACIONES','Actualizar tipos de habitaciones',NULL,'Permiso para actualizar tipos de habitaciones', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_CRE_ESTCAMAS','Crear estados de cama',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_ESTCAMAS'),'Permiso para crear estados de cama', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_UPD_ESTCAMAS','Actualizar estados de cama',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_ESTCAMAS'),'Permiso para actualizar estados de cama', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_CRE_TORRE','Crear torres a unidad organizacional',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_INFRUORG'),'Permiso para crear torres a unidad organizacional', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_CRE_PISO','Crear pisos a unidad organizacional',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_INFRUORG'),'Permiso para crear pisos a unidad organizacional', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_UPD_PISO','Actualizar piso a unidad organizacional',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_INFRUORG'),'Permiso para actualizar piso a unidad organizacional', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_CRE_CONSULTORIO','Crear consultorio a unidad organizacional',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_ADMPISO'),'Permiso para crear consultorio a unidad organizacional', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_UPD_CONSULTORIO','Actualizar consultorio de unidad organizacional',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_ADMPISO'),'Permite actualizar consultorio de unidad organizacional', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_CRE_HABITACION','Crear habitación a unidad organizacional',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_ADMPISO'),'Permiso para crear habitación a unidad organizacional', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_UPD_HABITACION','Actualizar habitación a unidad organizacional',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_ADMPISO'),'Permite actualizar habitación a unidad organizacional', 'Activo');
INSERT INTO SEG_PERMISOS (CODIGO,NOMBRE,PADRE_ID, DESCRIPCION, ESTADO) VALUES ('ADMIN_CRE_CAMA','Crear camas a unidad organizacional',(SELECT T.ID FROM SEG_PERMISOS T WHERE T.CODIGO='ADMIN_REA_ADMPISO'),'Permite crear camas a unidad organizacional', 'Activo');
COMMIT; 
