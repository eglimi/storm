# Manual:
# http://msdn.microsoft.com/library/default.asp?url=/library/en-us/vcug98/html/_asug_search_paths_in_rules.asp

# ================================
# Used Binaries

CSC=csc
CSCFLAGS=/nologo

SMITH=CodeSmithConsole
SMITHFLAGS=/nologo /debug+

# ================================
# Paths and Files

BIN=bin\Debug

BL=BusinessLayer
TPL=$(BL)\Templates
DM=$(BL)\DomainModel
DMI=$(BL)\DomainModelImpl
MAP=$(BL)\DataMapper

IMPLTPL=$(TPL)\ImplGen.cst
MAPPERTPL=$(TPL)\MapperGen.cst

DOMAIN=$(DM)\Person.cs \
       $(DM)\Address.cs \
       $(DM)\Order.cs \
       $(DM)\OrderDetail.cs \
       $(DM)\Product.cs
DOMAINIMPL=$(DMI)\PersonImpl.cs \
           $(DMI)\AddressImpl.cs \
           $(DMI)\OrderImpl.cs \
           $(DMI)\OrderDetailImpl.cs \
           $(DMI)\ProductImpl.cs
DOMAINXML=$(DOMAINIMPL:.cs=.xml)

MAPPER=$(MAP)\PersonMapper.cs \
       $(MAP)\AddressMapper.cs \
       $(MAP)\OrderMapper.cs \
       $(MAP)\OrderDetailMapper.cs \
       $(MAP)\ProductMapper.cs
MAPPERXML=$(MAPPER:.cs=.xml)


# ================================
# Inference Rules

{$(DMI)}.xml.cs:
	$(ECHO) [CodeSmithConsole] $< $*.cs
	$(SMITH) $(SMITHFLAGS) /properties:$< /out:$*.cs

{$(MAP)}.xml.cs:
	echo [CodeSmithConsole] $< $*.cs
	$(SMITH) $(SMITHFLAGS) /properties:$< /out:$*.cs

.SUFFIXES : .cs .xml


.SILENT :


# ================================
# Usage

all : 
	"echo.  Usage: $(MAKE) [clean] [mapper] [impl] [testapp]"
	"echo."
	"echo.     clean:    remove working files"
	"echo.     mapper:   generate Mapper files"
	"echo.     impl:     generate DomainModel files"


# ================================
# Building Rules

run : $(BL)\$(BIN)\testapp.exe
	cd $(BL)\$(BIN)
	testapp.exe
	cd $(MAKEDIR)

metadata : $(BL)\$(BIN)\BusinessLayer.dll $(BL)\$(BIN)\Mapper.dll

mapper : metadata $(MAPPER)
$(MAPPER) : $(MAPPERTPL)

impl : metadata $(DOMAINIMPL)
$(DOMAINIMPL) : $(IMPLTPL)

testapp : $(BL)\$(BIN)\testapp.exe

$(BL)\$(BIN)\testapp.exe : $(BL)\$(BIN)\BusinessLayerImpl.dll  HsrOrderAppTest\Class1.cs
	echo [CSC] $@
	$(CSC) $(CSCFLAGS) /t:exe /out:$@ \
	/reference:Storm.dll;$(BL)\$(BIN)\BusinessLayer.dll \
	/linkres:$(BL)\$(BIN)\BusinessLayerImpl.dll \
	/linkres:$(BL)\$(BIN)\BusinessLayer.dll \
	/linkres:$(BL)\$(BIN)\Mapper.dll \
	HsrOrderAppTest\Class1.cs 

$(BL)\$(BIN)\testapp.dll : 

$(BL)\$(BIN)\BusinessLayer.dll : $(DOMAIN)
	echo [CSC] $@
	$(CSC) $(CSCFLAGS) /t:library /out:$@ /reference:Storm.dll /res:Storm.dll $(DOMAIN) 
		
$(BL)\$(BIN)\BusinessLayerImpl.dll : impl mapper
	echo [CSC] $@
	$(CSC) $(CSCFLAGS) /t:library /out:$@ /reference:$(BL)\$(BIN)\BusinessLayer.dll /reference:Storm.dll $(DOMAINIMPL)

$(BL)\$(BIN)\Mapper.dll : $(BL)\$(BIN)\BusinessLayer.dll $(MAPPER)
	echo [CSC] $@
	$(CSC) $(CSCFLAGS) /t:library /out:$@ /reference:$(BL)\$(BIN)\BusinessLayer.dll /reference:Storm.dll $(MAPPER) 


# ================================
# Clean Up

clean :
	-del /s *.pdb
	-del /s *.dll
	-del /s *.netmodule
	-del /s *.exe
	-del $(DOMAINIMPL)
	-del $(MAPPER)
	-del /s /q $(BL)\$(BIN)
	

# ================================
# Create Directories

$(TMP) : 
	mkdir $@
	
$(BL)\$(BIN) :
	mkdir $@
