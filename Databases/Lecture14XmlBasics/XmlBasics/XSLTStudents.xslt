<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:template match="/">
      <html>
        <body>
          <h1>Students List</h1>
          <ul>
            <xsl:for-each select="/students/student">
              <li>
                <xsl:value-of select="name"/> |
                Course: <xsl:value-of select="course"/> |
                Specialty: <xsl:value-of select="speciality"/>
                <ul>
                  <xsl:for-each select="current()/exams/exam">
                    <li>
                    Course: <xsl:value-of select="name"/> |
                    Tutor: <xsl:value-of select="tutor"/> |
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
