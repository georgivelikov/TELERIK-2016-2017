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
        <title>videos</title>
      </head>
      <style>
        padding:5px;
      </style>
      <body>
        <h1>Videos</h1>
          <xsl:for-each select="videos/video">
            <h5>
              <xsl:value-of select="title"></xsl:value-of>
            </h5>
            <h5>
              <xsl:value-of select="author"></xsl:value-of>
            </h5>
            <iframe>
              <xsl:attribute name="src">
                <xsl:value-of select="link"/>
              </xsl:attribute>
            </iframe>
          </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
