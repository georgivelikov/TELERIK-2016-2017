<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet
      version="1.0"
      xmlns:students="urn:students"
      xmlns:exams="urn:exams"
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
      xmlns:msxsl="urn:schemas-microsoft-com:xslt"
      exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>XML Homework</title>
      </head>
      <style>
        .firstRow{
        background-color:#E0E0E0;
        }
        td{
        font-weight:bold;
        padding:5px;
        }
      </style>
      <body>
        <h1>Students</h1>
        <table border="1px solid black;">
          <tr class="firstRow">
            <td>Name</td>
            <td>Gender</td>
            <td>Brith Date</td>
            <td>Phone Number</td>
            <td>Email</td>
            <td>Course</td>
            <td>Specialty</td>
            <td>Faculty Number</td>
          </tr>
          <xsl:for-each select="students/students:student">
            <tr>
              <td>
                <xsl:value-of select="students:name"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="students:sex"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="students:birth-date"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="students:phone"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="students:email"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="students:course"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="students:specialty"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="students:faculty-number"></xsl:value-of>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>

  </xsl:template>
</xsl:stylesheet>
