<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  
    <xsl:template match="/">
      <html>
        <xsl:for-each select="/students/student">
          <h3>
            <xsl:value-of select="name"/>
          </h3>
        </xsl:for-each>
      </html>
        
    </xsl:template>
</xsl:stylesheet>
