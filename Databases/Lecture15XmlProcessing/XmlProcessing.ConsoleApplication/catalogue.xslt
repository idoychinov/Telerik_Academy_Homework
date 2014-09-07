<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

  <xsl:template match="/">
    <html>
      <body>
        <h1>Albums</h1>
        <ul>
          <xsl:for-each select="/catalogue/album">
            <li>
              Album Name: <xsl:value-of select="name"/> |
              Artist: <xsl:value-of select="artist"/> |
              Year: <xsl:value-of select="year"/>
              <ul>
                Songs:
                <xsl:for-each select="current()/songs/song">
                  <li>
                    Title: <xsl:value-of select="title"/> |
                    Duration: <xsl:value-of select="duration"/> |
                    Score: <xsl:value-of select="score"/>
                  </li>
                </xsl:for-each>
              </ul>
            </li>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
