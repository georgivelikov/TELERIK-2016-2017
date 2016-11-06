<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet
      version="1.0"
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
      xmlns:msxsl="urn:schemas-microsoft-com:xslt"
      exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Albums</title>
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
        <h1>Albums</h1>
        <table border="1px solid black;">
          <tr class="firstRow">
            <td>Name</td>
            <td>Artist</td>
            <td>Year</td>
            <td>Producer</td>
            <td>Price</td>
          </tr>
          <xsl:for-each select="catalog/album">
            <tr>
              <td>
                <xsl:value-of select="name"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="artist"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="year"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="producer"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="price"></xsl:value-of>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

