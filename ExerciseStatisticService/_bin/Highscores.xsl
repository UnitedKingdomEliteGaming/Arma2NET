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
					<td class="headb" style="text-align:left" colspan="3"><xsl:value-of select="Description"/></td>
				</tr>
		
				<tr>
					<td class="leftc" style="text-align:left">Name</td>
					<td class="leftc" style="text-align:left">Score</td>
					<td class="leftc" style="text-align:left">Datum</td>
				</tr>

				<xsl:for-each select="Entry">
					<xsl:sort select="Score" order="descending" data-type="number"/>
					<tr>
						<td class="leftb"><xsl:value-of select="Name"/></td>
						<td class="leftb"><xsl:value-of select="Score"/></td>
						<td class="leftb"><xsl:value-of select="Date"/></td>
					</tr>
				</xsl:for-each>
			
	        </table>
			<br/>

		</xsl:for-each>
		
    </xsl:for-each>
	
</xsl:template>
</xsl:stylesheet>

