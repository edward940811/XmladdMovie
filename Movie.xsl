<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:n="http://www.public.asu.edu/~eyang12/Movie" version="1.0">
	<xsl:template match="/">
		<html>  <body>
			<h1>Movies</h1>
			<table border="1">
				<tr bgcolor="yellow"> 
					<td><b>Rating</b></td>
					<td><b>Title</b></td>
					<td><b>Runtime</b></td>  
					<td><b>Genre</b></td> 
					<td><b>Studio</b></td> 
					<td><b>Year</b></td>
					<td><b>Director</b></td> 
					<td><b>High-Rated-Movie</b></td> 
				</tr>
				<xsl:for-each select="n:Movies/n:Movie">
					<xsl:sort select="n:Title"/>
					<tr style="font-size: 10pt; font-family: verdana">
						<td><xsl:value-of select="@Rating"/></td>
						<td><xsl:value-of select="n:Title"/></td>
						<td><xsl:value-of select="n:Title/@Runtime"/></td>
						<td><xsl:value-of select="n:Genre"/></td>
						<td><xsl:value-of select="n:Studio"/></td>
						<td><xsl:value-of select="n:Year"/></td>
						<xsl:for-each select="n:Director">
								<td><xsl:value-of select="n:Name/n:First"/> <xsl:value-of select="n:Name/n:Last"/></td>
								<td><xsl:value-of select="@High-rated-movie"/></td>
						</xsl:for-each>
					</tr>
				</xsl:for-each>
			</table>
		</body> </html>
	</xsl:template>
</xsl:stylesheet>
