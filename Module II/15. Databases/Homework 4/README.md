<!-- section start -->

<!-- attr: {id: 'title', class: 'slide-title', hasScriptWrapper: true} -->

# XML Basics
## Basic XML Concepts, Schemas, XPath, XSL
<div class="signature">
    <p class="signature-course">Databases</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href="http://academy.telerik.com" class="signature-link">http://academy.telerik.com</a>
</div>

<!-- section start -->
<!-- attr: {id: 'table-of-contents'} -->
# Table of Contents
* [What is XML?](#what-is-xml)
* [XML and HTML](#xml-and-html)
* [When to use XML?](#when-to-use-xml)
* [Namespaces](#namespaces)
* [Schemas and validation](#xml-schemas-and-validation)
  * DTD and XSD Schemas
* [XML Parsers](#xml-parsers)
* [XPath Language](#xpath)
* [XSL Transformations](#xsl-transformations)

<!-- section start -->
<!-- attr: {id: 'what-is-xml', class: 'slide-section', showInPresentation:true} -->
<!-- # What is XML?
## Extensible Markup Language -->

# What is XML
* `XML` (e`X`tensible `M`arkup `L`anguage)
  * Universal language (notation) for describing structured data using **text with tags**
  * The data is stored together with the meta-data about it
  * Used to describe other languages (formats) for data representation
* XML looks like HTML
  * Text based language, uses tags and attributes

<!-- attr: { showInPresentation:true } -->
<!-- # What is XML -->
* Worldwide standard
  * supported by the W3C - [www.w3c.org](http://www.w3.org/)
* Independent of
  * Hardware platform
  * Operating system
  * Programming languages

<!-- attr: { hasScriptWrapper:true } -->
# XML – Example

```xml
<?xml version="1.0"?>
<library name=".NET Developer's Library">
  <book>
    <title>Professional C# 4.0 and .NET 4</title>
    <author>Christian Nagel</author>
    <isbn>978-0-470-50225-9</isbn>
  </book>
  <book>
    <title>Silverlight in Action</title>
    <author>Pete Brown</author>
    <isbn>978-1-935182-37-5</isbn>
  </book>
</library>
```

<ul class="fragment">
  <li class="balloon" style="left:10%; top:11%">XML header tag (prolog)</li>
  <li class="balloon" style="left:50%; top:15%">Attribute (key / value pair)</li>
  <li class="balloon" style="width:120px; left:-9%; top:22%">Root (document) element</li>
  <li class="balloon" style="left:18%; top:45%">Opening tag</li>
  <li class="balloon" style="left:56%; top:38%">Element</li>
  <li class="balloon" style="left:20%; top:62%">Closing tag</li>
  <li class="balloon" style="left:43%; top:62%">Element value</li>
</ul>

<!-- section start -->
<!-- attr: {id: 'xml-and-html', class: 'slide-section', showInPresentation:true} -->
<!-- # XML and HTML
## Similarities and Differences -->

# XML and HTML
* Similarities between XML and HTML
  * Both are text based notations
  * Both use tags and attributes
* Differences between XML and HTML
  * HTML is a language, and XML is a syntax for describing other languages
  * HTML describes the formatting of information, XML describes structured information
  * XML requires the documents to be well-formatted

# Well-Formatted XML Documents
* Well-formatted XML:
  * All tags should be closed in the correct order of nesting
  * Attributes should always be closed
  * The document should contain only one root element
  * Tag and attribute names retain certain restrictions

<!-- attr: { hasScriptWrapper:true, showInPresentation:true } -->
<!-- # Well-Formatted XML Documents -->
* Example of incorrect XML document

```xml
<xml>
    <button bug! value="OK name="b1">
        <animation source="demo1.avi"> 1 < 2 < 3
    </click-button>
< / xml >
```
* * Open / close tags do not match
  * Unclosed attribute values
  * Invalid characters
  * …

<!-- section start -->
<!-- attr: {id: 'when-to-use-xml', class: 'slide-section', showInPresentation:true} -->
<!-- # When to Use XML
## Advantages and Disadvantages of XML -->

# When to Use XML
* Advantages of XML:
  * XML is human readable (unlike binary formats)
  * Any kind of structured data can be stored
  * Data comes with self-describing meta-data
  * Custom XML-based languages can be developed for certain applications
  * Information can be exchanged between different systems with ease
  * Unicode is fully supported

<!-- attr: { showInPresentation:true } -->
<!-- # When to Use XML -->
* Disadvantages of XML:
  * XML data is bigger (takes more space) than in binary formats
    * More memory consumption, more network traffic, more hard-disk space
  * Decreased performance
    * Need of parsing / constructing the XML tags
* XML is not suitable for all kinds of data
  * E.g. graphics, images and video clips

<!-- section start -->
<!-- attr: {id: 'namespaces', class: 'slide-section', showInPresentation:true} -->
<!-- # XML Namespaces -->

<!-- attr: { hasScriptWrapper:true } -->
# Namespaces
* XML namespaces are defined like this:

```xml
<?xml version="1.0" encoding="utf-8"?>
<sample:towns
  xmlns:sample="http://www.academy.com/towns/1.0">
  <sample:town>
    <sample:name>Sofia</sample:name>
    <sample:population>1200000</sample:population>
  </sample:town>
  <sample:town>
     <sample:name>Plovdiv</sample:name>
     <sample:population>700 000</sample:population>
  </sample:town>
</sample:towns>
```
<!-- attr: { hasScriptWrapper:true, showInPresentation:true } -->
<!-- # Namespaces -->
* Namespaces in XML documents allow using different tags with the same name:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<country:towns
    xmlns:country="urn:academy-com:country"
    xmlns:town="http://www.academy.com/towns/1.0">
  <town:town>
    <town:name>Plovdiv</town:name>
    <town:population>700 000</town:population>
    <country:name>Bulgaria</country:name>
  </town:town>
</country:towns>
```

<!-- attr: { hasScriptWrapper:true } -->
# Namespaces - Example

```xml
<?xml version="1.0" encoding="UTF-8"?>
<country:towns xmlns:country="urn:academy-com:country"
     xmlns:town="http://www.academy.com/towns/1.0">
  <town:town>
    <town:name>Sofia</town:name>
    <town:population>1 200 000</town:population>
    <country:name>Bulgaria</country:name>
  </town:town>
  <town:town>
    <town:name>Plovdiv</town:name>
      <town:population>700 000</town:population>
      <country:name>Bulgaria</country:name>
  </town:town>
</country:towns>

```
<div class="fragment">
  <div class="balloon" style="width:400px; left:62%; top:12%">Namespace with prefix "country" and URI "urn:academy-com:country"</div>
  <div class="balloon" style="width:400px; left:30%; top:67%">Tag named "name" from namespace "country" -> the full tag name is "urn:academy-com:country:name"
</div>

<!-- attr: { hasScriptWrapper:true, showInPresentation:true } -->
<!-- # Namespaces - Example -->

```xml
<?xml version="1.0" encoding="windows-1251"?>
<order xmlns="http://www.supermarket.com/orders/1.1">
  <item>
    <name>Beer "Zagorka"</name>
    <ammount>8</ammount>
    <measure>bottle</measure>
    <price>5.60</price>
  </item>
  <item>
    <name>Meat balls</name>
    <ammount>12</ammount>
    <measure>amount</measure>
    <price>5.40</price>
  </item>
</order>
```
<div class="fragmentz balloon" style="width:400px; left:54%; top:27%">Default namespace – applied for the entire XML document</div>

<!-- section start -->
<!-- attr: {id: 'xml-schemas-and-validation', class: 'slide-section', showInPresentation:true} -->
<!-- # XML Schemas and Validation
## DTD and XSD Schemas -->

# XML Schemas and Validation
* The XML documents structure is defined by schemas
* `XML schemas` describes:
  * Possible attributes and tags and their values
  * Tags order
  * Default values and number of appearances
* There are few XML Schema standards:
  * `DTD` – Document Type Definition
  * `XSD` – XML Schema Definition Language

<!-- attr: { hasScriptWrapper:true } -->
# The DTD Language
* `DTD` (`D`ocument `T`ype `D`efinition) is:
  * Formal language for describing XML document structures
  * Contains a set of rules for the tags and their attributes in a document
  * Text-based language, but not XML based
  * Substituted by XSD (relatively rarely used)

```xml
<!ELEMENT library (book+)>
<!ATTLIST library name CDATA #REQUIRED>
<!ELEMENT book (title, author, isbn)>
<!ELEMENT title (#PCDATA)>
<!ELEMENT author (#PCDATA)>
```

# XSD Schemas
* `XSD` (`X`ML `S`chema `D`efinition Language)
  * Powerful XML-based language for describing the structure of XML documents
  * Contains a set of rules for the tags and their attributes in a document
  * Specifies few standard data types
    * Numbers, dates, strings, etc.
  * XSD Schemas have greater descriptive power than `DTD`

<!-- attr: { hasScriptWrapper:true } -->
# XSD Schemas – Example

```xml
<?xml version="1.0" encoding="UTF-8"?>
<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema"
	targetNamespace="https://telerikacademy.com">
    <xs:element name="library">
        <xs:complexType>
            <xs:sequence>
                <xs:element ref="book"
                    maxOccurs="unbounded"/>
            </xs:sequence>
            <xs:attribute name="name"
                type="xs:string" use="optional"/>
        </xs:complexType>
    </xs:element>
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
<!-- # XSD Schemas – Example -->

```xml
    <xs:element name="book">
        <xs:complexType>
            <xs:sequence>
                <xs:element ref="title"/>
                <xs:element ref="author"/>
                <xs:element ref="isbn"/>
            </xs:sequence>
        </xs:complexType>
    </xs:element>
    <xs:element name="title" type="xs:string"/>
    <xs:element name="author" type="xs:string"/>
    <xs:element name="isbn" type="xs:string"/>
</xs:schema>
```

<!-- attr: { hasScriptWrapper:true, style:'font-size:0.9em' } -->
# Reference DTD and XSD

```xml
<?xml version="1.0"?>
<!DOCTYPE library SYSTEM "[file path]">
<library>
  <book>
    <title>Professional C# 4.0 and .NET 4</title>
    <author>Christian Nagel</author>
    <isbn>978-0-470-50225-9</isbn>
  </book>
</library>
```

```xml
<?xml version="1.0"?>
<library xmlns="[namespace]"
 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
 xsi:schemaLocation="[namespace path]">
  <book>
    <title>Professional C# 4.0 and .NET 4</title>
    <author>Christian Nagel</author>
    <isbn>978-0-470-50225-9</isbn>
  </book>
</library>
```

<!-- attr: { hasScriptWrapper:true } -->
# Visual Studio Schema Editor
* Visual Studio can generate XSD Schemas from the structure of a given XML document
* VS has powerful XSD Schema Editor
  * Visually edit schemas
<img class="slide-image" src="imgs/vs-schema-editor.png" style="left:5%; top:45%" />

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Working with the XSD Editor in Visual Studio
## Demo -->

<!-- section start -->
<!-- attr: {id: 'xml-parsers', class: 'slide-section', showInPresentation:true} -->
<!-- # XML Parsers
## DOM, SAX, StAX -->

# XML Parsers
* `XML parsers` are programming libraries that make the work with XML easier
* They serve for:
  * Extracting data from XML documents
  * Modifying existing XML documents
  * Building new XML documents
  * Validating XML documents by given schema
  * Transforming XML documents

# XML Working Models
* They have several working models:
  * `DOM` (Document Object Model)
    * Represents XML documents as a tree in the memory
    * Allows processing and modifying the document
  * `SAX` (Simple API for XML Processing)
    * Reads XML documents consequently element by element
    * Event-driven API
    * Allows analyzing the read portions at each step
  * `StAX` (Streaming API for XML)
    * Like SAX but works in "pull" mode

<!-- attr: { hasScriptWrapper:true } -->
# The DOM Parser
* Given the following XML document:

```xml
<?xml version="1.0"?>
<library name=".NET Developer's Library">
  <book>
    <title>Professional C# 4.0 and .NET 4</title>
    <author>Christian Nagel</author>
    <isbn>978-0-470-50225-9</isbn>
  </book>
  <book>
    <title>Silverlight in Action</title>
    <author>Pete Brown</author>
    <isbn>978-1-935182-37-5</isbn>
  </book>
</library>
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
<!-- # The DOM Parser -->
* This document is represented in the memory as a DOM tree in the following way:
<img class="slide-image" src="imgs/dom-parser.png" style="left:0%; top:28%" />

# The SAX Parsers
* The `SAX parsers`:
  * Iterate the document consequently tag by tag
  * Invoke callback functions (events) when particular node is reached
  * Stream-like access – going backwards or jumping ahead is not allowed
  * Require many times less resources (memory and loading time)
  * Work well over streams

# The StAX Parser
* `StAX` is like SAX but
  * "Pull"-based parser
  * Not event driven (not callback based)
  * Developer manually say "go to next element" and analyse it
* `SAX` vs. `StAX`
  * SAX reads the documents and invokes callbacks like "node found", "attribute found", etc.
  * In StAX parsers the read is invoked by the developer synchronously

# When to Use DOM and When to Use SAX / StAX?
* Use `DOM` processing model when:
  * Process not big documents (e.g. less than 10 MB)
  * There is a need of flexibility
  * To modify XML documents
* Use `SAX` / `StAX` processing model when:
  * Process big documents
  * The performance is important
  * There is no need to change the document

<!-- section start -->
<!-- attr: {id: 'xpath', class: 'slide-section', showInPresentation:true} -->
<!-- # XPath -->

# XPath
* `XPath` (`X`ML `P`ath `L`anguage) is a language for addressing parts of XML documents
* XPath expressions contains description of paths to nodes and filter criteria
* Example for XPath expressions:

```xml
/library/book[isbn='1-930110-19-7']
```
```xml
/catalog/cd[@price<10.80]
```
```xml
/book/chapter[3]/paragraph[last()]
```

<!-- attr: { style:'font-size:0.85em' } -->
# XPath Expressions
* `/` – addresses the root element `derived`
* `/someNode` – addresses all nodes with name "someNode", straight inheritors to the root
* `/books/book` – addresses all nodes  "book", straight inheritors to the node "books"
* `/books/book[price<10]/author` – addresses all authors (`/books/book/author`), whose books have price < 10
* `/items/item[@type="food"]` – addresses all nodes with name item (`/items/item/`), which have attribute "`type`" with value "`food`"

<!-- section start -->
<!-- attr: {id: 'xsl-transformations', class: 'slide-section', showInPresentation:true} -->
<!-- # XSL Transformations -->

# XSL Transformations
* `XSL transformations` (`XSLT`) allows to
  * Transform of one XML document to other XML document with different structure
  * Convert between different XML formats
* `XSLT` depends on `XPath`
  * XPath is used to match parts from the input document and replace them with another XML
* In particular `XSLT` can be used for transforming `XML` documents to `XHTML`

<!-- attr: { hasScriptWrapper:true, style:'font-size:0.8em' } -->
# XSL Stylesheet – Example

```xml
<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">  
  <html>
    <body>
      <h1>My library</h1>
      <table bgcolor="#E0E0E0" cellspacing="1">
        <tr bgcolor="#EEEEEE">
          <td><b>Title</b></td>
          <td><b>Author</b></td>
        </tr>
        <xsl:for-each select="/library/book">
          <tr bgcolor="white">
            <td><xsl:value-of select="title"/></td>
            <td><xsl:value-of select="author"/></td>
          </tr>
        </xsl:for-each>
      </table>
    </body>
  </html>
</xsl:template>
</xsl:stylesheet>
```
<!-- attr: { style:'font-size:0.9em' } -->
# The XSL Language
* `&lt;xsl:template match="XPath expr."> … &lt;/xsl:template>` – replaces the pointed with XPath expression part of the document with the construction body
* `&lt;xsl:for-each select="XPath expr."> … &lt;/xsl:for-each>` – replaces each node, pointed by the XPath expression with construction body
* `&lt;xsl:value-of select="XPath expr."/>` – extracts the value of the given XPath expression (the first occurrence)
* XSL patterns are valid XML documents!


<!-- section start -->
<!-- attr: {id: 'questions', class: 'slide-section', showInPresentation:true} -->
<!-- # Questions
## XML Basics -->
