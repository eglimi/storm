CSC=csc
CSCFLAGS=/nologo
SN=sn
SNFLAGS=-q
AL=al
ALFLAGS=/nologo
GACUTIL=gacutil
GACUTILFLAGS=/nologo

BIN=bin\Debug

ATTRDIR=Attributes
LIBDIR=Lib
LDRDIR=Loader

ATTR=$(ATTRDIR)\Adder.cs \
		$(ATTRDIR)\Column.cs \
		$(ATTRDIR)\DomainObjectImpl.cs \
		$(ATTRDIR)\Factory.cs \
		$(ATTRDIR)\Finder.cs \
		$(ATTRDIR)\GenerateCode.cs \
		$(ATTRDIR)\MapperImpl.cs \
		$(ATTRDIR)\ParameterDef.cs \
		$(ATTRDIR)\PrimaryKey.cs \
		$(ATTRDIR)\Table.cs \
		$(ATTRDIR)\ToMany.cs \
		$(ATTRDIR)\ToOne.cs \
		$(ATTRDIR)\VersionField.cs
LIB=$(LIBDIR)\Criteria.cs \
		$(LIBDIR)\DomainObject.cs \
		$(LIBDIR)\Exceptions.cs \
		$(LIBDIR)\IdentityMap.cs \
		$(LIBDIR)\IFactory.cs \
		$(LIBDIR)\IFinder.cs \
		$(LIBDIR)\IMapper.cs \
		$(LIBDIR)\Key.cs \
		$(LIBDIR)\QueryObject.cs \
		$(LIBDIR)\Registry.cs \
		$(LIBDIR)\Timestamp.cs \
		$(LIBDIR)\ToManyRelation.cs \
		$(LIBDIR)\ToOneRelation.cs \
		$(LIBDIR)\UnitOfWork.cs
LDR=$(LDRDIR)\AssemblyLoader.cs \
		$(LDRDIR)\AssemblyLoaderEditor.cs \
		$(LDRDIR)\XmlSerializerTypeConvertor.cs

SECKEY=stormPrivate.key

.SILENT :

all : 
	echo Usage:  $(MAKE) [clean] [uninstall] [build] [install]

build : keys $(BIN)\Storm.dll

install : uninstall $(BIN)\Storm.dll
	echo [GACUTIL] install Storm
	$(GACUTIL) $(GACUTILFLAGS) /i $(BIN)\Storm.dll
	
uninstall : fixgac
	echo [GACUTIL] uninstall Storm
	$(GACUTIL) $(GACUTILFLAGS) /u Storm

fixgac : 
	echo [REGEDIT] Fixing incorrect registry entry ...
	regedit /s <<
Windows Registry Editor Version 5.00
[HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Installer\Assemblies\Global]
@=-
<<

keys : $(BIN)
	echo [SN] $(SECKEY)
	$(SN) $(SNFLAGS) -k $(SECKEY)

$(BIN)\Storm.dll : $(BIN) AssemblyInfo.cs $(ATTR) $(LDR) $(LIB)
	echo [CSC] $@
	$(CSC) $(CSCFLAGS) /t:library /out:$@ AssemblyInfo.cs $(ATTR) $(LDR) $(LIB)

$(BIN) : 
	echo [mkdir] $@
	mkdir $@
	
clean :
	echo [clean] Keys
	-if exist $(SECKEY) del $(SECKEY)
	echo [clean] *.pdb
	-if exist *.pdb del /s *.pdb 
	echo [clean] *.dll
	-if exist *.dll del /s *.dll
	echo [clean] *.netmodule
	-if exist *.netmodule del /s *.module
	echo [clean] *.exe
	-if exist *.exe del /s *.exe
	echo [clean] $(BIN)
	-if exist $(BIN) rmdir /s /q $(BIN)
	echo [clean] obj
	-if exist obj rmdir /s /q obj
