import xml.etree.ElementTree as ET

datos = [
    ("ARCOS GOMEZ", "CRISTIAN CAMILO", 23, 9, 89, 87, 52),
    ("BARRERA MURIEL", "MEYLIN VIVIANA", 98, 8, 98, 86, 72.5),
    ("BOLAÑOS MUÑOZ", "YEFERSON RIKI", 56, 78, 67, 67, 50.25),  # ✅ Corregido
    ("BRAVO OBANDO", "MAURICIO JAVIER", 78, 67, 78, 78, 75.25),
    ("CABRERA BEDOYA", "MONICA ANDREA", 78, 87, 78, 86, 82.25),
    ("CAMILO MOSQUERA", "RENE ALBERTO", 87, 98, 99, 67, 87.75),
    ("DAZA GUZMAN", "OSCAR JAVIER", 45, 56, 67, 90, 64.5),
    ("ERAZO CASTRO", "LUIS FELIPE", 56, 78, 98, 77, 77.25),
    ("FERNANDEZ MUÑOZ", "TATIANA", 67, 87, 88, 89, 82.75),
    ("GALLEGO SARRIA", "JUAN CARLOS", 89, 89, 78, 89, 86.25),
    ("GOMEZ ENRIQUEZ", "DIANA STEFANIA", 87, 89, 87, 98, 90.25)
]

# Creación del documento XML
root = ET.Element("ListadoNotas")

for apellido, nombre, mes1, mes2, mes3, mes4, promedio in datos:
    estudiante = ET.SubElement(root, "Estudiante")
    ET.SubElement(estudiante, "Apellidos").text = apellido
    ET.SubElement(estudiante, "Nombres").text = nombre
    ET.SubElement(estudiante, "NotaMes1").text = str(mes1)
    ET.SubElement(estudiante, "NotaMes2").text = str(mes2)
    ET.SubElement(estudiante, "NotaMes3").text = str(mes3)
    ET.SubElement(estudiante, "NotaMes4").text = str(mes4)
    ET.SubElement(estudiante, "Promedio").text = str(promedio)

# Guardar el XML en un archivo
arbol = ET.ElementTree(root)
arbol.write("notas.xml", encoding="utf-8", xml_declaration=True)

print("Archivo XML generado exitosamente.")
