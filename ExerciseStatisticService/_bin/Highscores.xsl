<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  
    <xsl:for-each select="DatabaseXml/Category">
		<table border="1" class="forum" style="width: 90%;" cellpadding="0">
			<tr>
				<td class="headb"><xsl:value-of select="Description"/></td>
			</tr>
			<tr>
			</tr>
		</table>
		<br/>
  
		<xsl:for-each select="Exercise">
			<table border="1" class="forum" style="width: 90%;" cellpadding="0">
				<tr>
					<td class="headb" style="text-align:left" colspan="4"><xsl:value-of select="Description"/></td>
				</tr>
		
				<tr>
					<td class="leftc" width="400px" style="text-align:left">Name</td>
					<td class="leftc" width="100px" style="text-align:left">Punkte</td>
					<td class="leftc" style="text-align:left">Datum</td>
					<td class="leftc" width="50px" style="text-align:left">Erf.</td>
				</tr>

				<xsl:for-each select="Entry">
					<xsl:sort select="Score" order="descending" data-type="number"/>
					<xsl:sort select="Date" order="ascending" data-type="text"/>
					<tr>
						<td class="leftb"><xsl:value-of select="Name"/></td>
						<td class="leftb"><xsl:value-of select="Score"/></td>
						<td class="leftb"><xsl:value-of select="Date"/></td>
						<xsl:choose>
							<xsl:when test="../Required>Score">
								<td class="leftb"><img alt="" src="/csv2/symbols/clansphere/red.gif"></img></td>
							</xsl:when>
							<xsl:otherwise>
								<td class="leftb"><img alt="" src="/csv2/symbols/clansphere/green.gif"></img></td>
							</xsl:otherwise>
						</xsl:choose>						
					</tr>
				</xsl:for-each>
			
	        </table>
			<br/>

		</xsl:for-each>
		
    </xsl:for-each>
	
</xsl:template>
</xsl:stylesheet>