<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:pdcl="http://pinneddown.org/cardlist">
	
	<xsl:template match="/">
		<!-- show card list name -->
		<!--<h2><xsl:value-of select="pdcl:CardList/pdcl:longName"/></h2>-->
		
		<!-- begin card list table -->
		<table>
			<tr align="left">
				<th><b>Card Index</b></th>
				<th><b>Card Name</b></th>
				<th><b>Type</b></th>
				<th><b>Affiliation</b></th>
			</tr>
			
			<!-- add cards -->
			<xsl:for-each select="pdcl:CardList/pdcl:cards">
				<xsl:apply-templates/> 
			</xsl:for-each>
		</table>
	</xsl:template>

	<xsl:template match="pdcl:Character|pdcl:Effect|pdcl:Equipment|pdcl:Starship|pdcl:Location|pdcl:Damage">
		<tr>
			<!-- show card index -->
			<td><xsl:value-of select="pdcl:Index"/></td>
			
			<!-- show card name -->
			<td>
				<a href="https://github.com/npruehs/PinnedDown/raw/master/resource/png/cards/{/pdcl:CardList/pdcl:index}%20{/pdcl:CardList/pdcl:shortName}/{pdcl:Affiliation}/{pdcl:Type}/{pdcl:Name}.png">
					<xsl:if test="pdcl:Unique = 'true'">*</xsl:if>
					<xsl:value-of select="pdcl:Name"/>
				</a>
			</td>
			
			<!-- show card type -->
			<td>
				<xsl:value-of select="pdcl:Type"/>
				
				<xsl:if test="pdcl:ShipClass">
					- <xsl:value-of select="pdcl:ShipClass"/>
				</xsl:if>
			</td>
			
			<!-- show card affiliation -->
			<td>
				<xsl:choose>
					<xsl:when test="pdcl:Affiliation">
						<xsl:value-of select="pdcl:Affiliation"/>
					</xsl:when>
					<xsl:otherwise>
						-
					</xsl:otherwise>
				</xsl:choose>
			</td>      
		</tr>
	</xsl:template>
</xsl:stylesheet>
