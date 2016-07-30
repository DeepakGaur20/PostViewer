<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" />
  <xsl:template match="/">
    <html>
      <head>
        <script type="text/css">
          body
          {
          font-family:perpetua, Arial, san-serif;
          font-size:5;
          }
        </script>
      </head>
      <body>
        <table border="1">
          <th>userId</th>
          <th>id</th>
          <th>title</th>
          <th>body</th>
          <xsl:for-each select="root">
            <tr>
              <td>
                <xsl:value-of select="userId"/>
              </td>
              <td>
                <xsl:value-of select="id"/>
              </td>
              <td>
                <xsl:value-of select="title"/>
              </td>
              <td>
                <xsl:value-of select="body"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
