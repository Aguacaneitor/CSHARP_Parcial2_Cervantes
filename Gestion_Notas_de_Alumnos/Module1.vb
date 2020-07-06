Module Module1
    Dim matriculas(0) As Int32
    Dim nombresApellidos(0) As String
    Dim cicloElectivoAlumno(0) As String
    Dim materias(0) As String
    Dim materia1(0) As String
    Dim materia2(0) As String
    Dim notas1M1(0) As Double
    Dim notas2M1(0) As Double
    Dim notas_practicoM1(0) As Double
    Dim notas1M2(0) As Double
    Dim notas2M2(0) As Double
    Dim notas_practicoM2(0) As Double

    Sub Main()
        MenuPrincipal()
    End Sub

    Sub MenuPrincipal()
        Dim enEjecucion As Boolean = True
        While enEjecucion
            Console.Clear()
            Console.WriteLine(" --------------------------------------------------")
            Console.WriteLine("|****BIENVENIDO AL SISTEMA DE GESTIÓN DE NOTAS*****|")
            Console.WriteLine(" --------------------------------------------------")
            Console.WriteLine("   |INGRESE LA OPCIÓN|      | 1) REGISTRO DE MATERIA|")
            Console.WriteLine("    -----------------       | 2) REGISTRO DE ALUMNO |")
            Console.WriteLine("                            | 3) ASIGNAR MATERIAS   |")
            Console.WriteLine("                            | 4) REGISTRO DE NOTAS  |")
            Console.WriteLine("                            | 5) VER ESTADISTICAS   |")
            Console.WriteLine("                            | 6) VER ALUMNOS        |")
            Console.WriteLine("                            | 7) VER MATERIAS       |")
            Console.WriteLine("                            | 8) RESUMEN DE ALUMNO  |")
            Console.WriteLine("                            | 0) SALIR              |")
            Console.WriteLine("                             ----------------------")
            Select Case (Console.ReadLine())
                Case 1
                    RegistroMateria()
                Case 2
                    RegistroDeAlumno()
                Case 3
                    AsignarMaterias()
                Case 4
                    RegistroDeNotas()
                Case 5
                    verEstadisticas()
                Case 6
                    verAlumnos()
                Case 7
                    verMaterias()
                Case 8
                    verMateriasAlumno()
                Case 0
                    enEjecucion = False
            End Select
        End While
    End Sub
    'Matricula
    'Nombre y Apellido 
    'Materia
    'Ciclo lectivo
    'Nota parcial 1
    'Nota parcial 2
    'Nota trabajo práctico
#Region "Opción 2"
    Sub RegistroDeAlumno()
        Dim nombre As String
        Dim apellido As String
        Dim matricula As Int32
        Dim año As Int32
        Dim cuatrimestre As Int32
        Dim cicloLectivo As String
        Dim verificadorMatricula As Boolean
        Dim verificadorCuatrimestre As Boolean
        Dim verificadorAño As Boolean
        verificadorMatricula = False
        verificadorAño = False
        verificadorCuatrimestre = False
        Console.WriteLine(" --------------------------------------------------" & vbNewLine & "|****BIENVENIDO AL SISTEMA DE GESTIÓN DE NOTAS*****|" _
                          & vbNewLine & " --------------------------------------------------")
        Do
            If verificadorMatricula Then
                Console.WriteLine("   ALUMNO YA REGISTRADO")
            End If
            Console.WriteLine("   INGRESE LA MATRICULA DEL ALUMNO:")
            matricula = Int(Console.ReadLine())
            verificadorMatricula = verificadorDeMatricula(matricula)
        Loop While verificadorMatricula

        Console.WriteLine("   INGRESE EL NOMBRE DEL ALUMNO:")
        nombre = Console.ReadLine()
        Console.WriteLine("   INGRESE EL APELLIDO DEL ALUMNO:")
        apellido = Console.ReadLine()
        Do
            Console.WriteLine("   INGRESE EL AÑO DEL CICLO LECTIVO:")
            año = Int(Console.ReadLine())
            If año > Year(Date.Today) Then
                verificadorAño = True
                Console.WriteLine("   AÑO INGRESADO NO VALIDO")
            Else
                verificadorAño = False
            End If
        Loop While verificadorAño
        Do
            Console.WriteLine("   INGRESE EL CUATRIMESTRE DEL CICLO LECTIVO:")
            cuatrimestre = Int(Console.ReadLine())
            If cuatrimestre > 2 Or cuatrimestre < 1 Then
                verificadorCuatrimestre = True
                Console.WriteLine("   CUATRIMESTRE INGRESADO NO VALIDO")
            Else
                verificadorCuatrimestre = False
            End If
        Loop While verificadorCuatrimestre
        cicloLectivo = año.ToString & cuatrimestre.ToString
        agregarAlumno(matricula, nombre & " " & apellido, cicloLectivo)
    End Sub
    Function verificadorDeMatricula(matricula As Int32) As Boolean
        Dim verificador As Boolean
        verificador = False
        For i = 0 To matriculas.Length - 1
            If matriculas(i) = matricula Then
                verificador = True
            End If
        Next
        Return verificador

    End Function


    'Crea y mantiene el orden de posiciones de todos los vectores
    Sub agregarAlumno(matricula As Int32, nombreCompleto As String, cicloLectivo As String)
        Dim matriculasRes() As Int32
        Dim nombresApellidosRes() As String
        Dim cicloElectivoAlumnoRes() As String
        matriculasRes = matriculas
        nombresApellidosRes = nombresApellidos
        cicloElectivoAlumnoRes = cicloElectivoAlumno
        ReDim matriculas(matriculas.Length)
        ReDim nombresApellidos(nombresApellidos.Length)
        ReDim cicloElectivoAlumno(cicloElectivoAlumno.Length)
        For i = 0 To matriculasRes.Length - 1
            matriculas(i) = matriculasRes(i)
        Next
        matriculas(matriculas.Length - 1) = matricula
        For i = 0 To nombresApellidosRes.Length - 1
            nombresApellidos(i) = nombresApellidosRes(i)
        Next
        nombresApellidos(nombresApellidos.Length - 1) = nombreCompleto
        For i = 0 To cicloElectivoAlumnoRes.Length - 1
            cicloElectivoAlumno(i) = cicloElectivoAlumnoRes(i)
        Next
        cicloElectivoAlumno(cicloElectivoAlumno.Length - 1) = cicloLectivo
        '-----Para mantener el orden apropiado de las materias y las notas------
        Dim materia1Res() As String
        Dim materia2Res() As String
        Dim notas1M1Res() As Double
        Dim notas2M1Res() As Double
        Dim notas_practicoM1Res() As Double
        Dim notas1M2Res() As Double
        Dim notas2M2Res() As Double
        Dim notas_practicoM2Res() As Double
        '----
        materia1Res = materia1
        materia2Res = materia2
        notas1M1Res = notas1M1
        notas2M1Res = notas2M1
        notas_practicoM1Res = notas_practicoM1
        notas1M2Res = notas1M2
        notas2M2Res = notas2M2
        notas_practicoM2Res = notas_practicoM2
        '----
        ReDim materia1(materia1.Length)
        ReDim materia2(materia2.Length)
        ReDim notas1M1(notas1M1.Length)
        ReDim notas2M1(notas2M1.Length)
        ReDim notas_practicoM1(notas_practicoM1.Length)
        ReDim notas1M2(notas1M2.Length)
        ReDim notas2M2(notas2M2.Length)
        ReDim notas_practicoM2(notas_practicoM2.Length)
        For i = 0 To materia1Res.Length - 1
            materia1(i) = materia1Res(i)
        Next
        For i = 0 To materia2Res.Length - 1
            materia2(i) = materia2Res(i)
        Next
        '------Materia 1
        For i = 0 To notas1M1Res.Length - 1
            notas1M1(i) = notas1M1Res(i)
        Next
        For i = 0 To notas2M1Res.Length - 1
            notas2M1(i) = notas2M1Res(i)
        Next
        For i = 0 To notas_practicoM1Res.Length - 1
            notas_practicoM1(i) = notas_practicoM1Res(i)
        Next
        '-----Materia 2
        For i = 0 To notas1M2Res.Length - 1
            notas1M2(i) = notas1M2Res(i)
        Next
        For i = 0 To notas2M2Res.Length - 1
            notas2M2(i) = notas2M2Res(i)
        Next
        For i = 0 To notas_practicoM2Res.Length - 1
            notas_practicoM2(i) = notas_practicoM2Res(i)
        Next

    End Sub
#End Region
#Region "Opción 1"
    Sub RegistroMateria()
        Dim materia As String
        Dim verificadorMateria As Boolean
        Console.WriteLine(" --------------------------------------------------" & vbNewLine & "|****BIENVENIDO AL SISTEMA DE GESTIÓN DE NOTAS*****|" _
                          & vbNewLine & " --------------------------------------------------")
        Do
            If verificadorMateria Then
                Console.WriteLine("   MATERIA YA REGISTRADA")
            End If
            Console.WriteLine("   INGRESE LA MATERIA A REGISTRAR:")
            materia = Console.ReadLine().ToUpper
            verificadorMateria = verificadorDeMateria(materia)
        Loop While verificadorMateria
        agregarMateria(materia)

    End Sub
    Function verificadorDeMateria(materia As String) As Boolean
        Dim verificador As Boolean
        verificador = False
        For i = 0 To materias.Length - 1
            If materias(i) = materia Then
                verificador = True
            End If
        Next
        Return verificador

    End Function
    Sub agregarMateria(materia As String)
        Dim materiasRes() As String
        materiasRes = materias
        ReDim materias(materias.Length)
        For i = 0 To materiasRes.Length - 1
            materias(i) = materiasRes(i)
        Next
        materias(materias.Length - 1) = materia
    End Sub
#End Region
#Region "Opción 3"
    Sub AsignarMaterias()
        Dim matricula As Int32
        Dim indiceMateria As Int32
        Dim contadorMaterias As Int32
        Dim verificarMatricula As Boolean
        Dim asignarMaterias As Boolean
        verificarMatricula = True
        asignarMaterias = True
        contadorMaterias = 0
        indiceMateria = 0
        Console.Clear()
        Console.WriteLine(" --------------------------------------------------" & vbNewLine & "|****BIENVENIDO AL SISTEMA DE GESTIÓN DE NOTAS*****|" _
                          & vbNewLine & " --------------------------------------------------")
        If matriculas.Length > 1 Then
            Do
                If Not verificarMatricula Then
                    Console.WriteLine("NO HAY ALUMNOS REGISTRADOS CON ESA MATRICULA")
                Else
                    Console.WriteLine("   INGRESE LA MATRICULA DEL ALUMNO:")
                End If
                matricula = Console.ReadLine()
                verificarMatricula = verificadorDeMatricula(matricula)
            Loop While Not verificarMatricula
            While (asignarMaterias)
                contadorMaterias = contadorMaterias + 1
                Dim indiceAnterior As Int32
                Console.WriteLine("   SELECCIONE EL INDICE DE LA MATERIA NÚMERO " & contadorMaterias & " A ASIGNAR:")
                For i = 1 To materias.Length - 1
                    Console.WriteLine(i & ") " & materias(i))
                Next
                Console.WriteLine("0) NO ASIGNAR MATERIA")
                indiceAnterior = indiceMateria
                indiceMateria = Console.ReadLine()
                If indiceMateria = 0 Then
                    asignarMaterias = False
                Else
                    If indiceMateria = indiceAnterior Then
                        Console.WriteLine("NO PUEDE ASIGNAR LA MISMA MATERIA AL MISMO ALUMNO")
                        contadorMaterias = contadorMaterias - 1
                    Else
                        asignarMateriaAlumno(matricula, indiceMateria, contadorMaterias)
                    End If
                End If
                    If contadorMaterias >= 2 Then
                    asignarMaterias = False
                End If
            End While
        Else
            Console.WriteLine("NO HAY ALUMNOS REGISTRADOS")
        End If
    End Sub
    Sub asignarMateriaAlumno(matricula As Int32, indiceMateria As Int32, contadorMaterias As Int32)
        Dim indice As Int32
        For i = 0 To matriculas.Length - 1
            If matriculas(i) = matricula Then
                indice = i
            End If
        Next
        If contadorMaterias = 1 Then
            materia1(indice) = materias(indiceMateria)
        Else
            materia2(indice) = materias(indiceMateria)
        End If
    End Sub
#End Region
#Region "Opción 4"
    Sub RegistroDeNotas()
        Dim matricula As Int32
        Dim contador As Int32
        Dim materia As Int32
        Dim nota As Double
        Dim verificarMatricula As Boolean
        Dim verificarNota As Boolean
        Dim verificadorMateria As Boolean
        verificarMatricula = True
        verificadorMateria = True
        materia = 0
        Console.Clear()
        If materias.Length > 1 And matriculas.Length > 1 Then
            Do
                If Not verificarMatricula Then
                    Console.WriteLine("NO HAY ALUMNOS REGISTRADOS CON ESA MATRICULA")
                Else
                    Console.WriteLine("   INGRESE LA MATRICULA DEL ALUMNO:")
                End If
                matricula = Console.ReadLine()
                verificarMatricula = verificadorDeMatricula(matricula)
            Loop While Not verificarMatricula
            Dim indice As Int32
            For i = 0 To matriculas.Length - 1
                If matriculas(i) = matricula Then
                    indice = i
                End If
            Next
            If materia1(indice) = "" Then
                verificadorMateria = False
                Console.WriteLine("EL ALUMNO SELECCIONADO NO TIENE MATERIAS ASIGNADAS")
            End If
            While verificadorMateria
                verificarNota = True
                contador = 0
                materia = materia + 1
                Console.WriteLine("MATERIA #" & materia)
                While verificarNota
                    contador = contador + 1
                    If contador > 2 Then
                        Console.WriteLine("   INGRESE LA NOTA DEL TRABAJO PRACTICO:")
                    Else
                        Console.WriteLine("   INGRESE LA NOTA #" & contador & " EVALUACIÓN:")
                    End If
                    nota = CDbl(Console.ReadLine())
                    If nota > 10 Or nota < 0 Then
                        Console.WriteLine("NOTA INGRESADA NO ES VALIDA")
                        contador = contador - 1
                    Else
                        Select Case materia
                            Case 1
                                Select Case contador
                                    Case 1
                                        notas1M1(indice) = nota
                                    Case 2
                                        notas2M1(indice) = nota
                                    Case 3
                                        notas_practicoM1(indice) = nota
                                        verificarNota = False
                                End Select
                            Case 2
                                Select Case contador
                                    Case 1
                                        notas1M2(indice) = nota
                                    Case 2
                                        notas2M2(indice) = nota
                                    Case 3
                                        notas_practicoM2(indice) = nota
                                        verificarNota = False
                                End Select
                        End Select
                    End If
                End While
                If materia2(indice) = "" Or materia >= 2 Then
                    verificadorMateria = False
                    Console.WriteLine("EL ALUMNO NO POSEE MAS MATERIAS PARA ASIGNAR NOTA")
                End If
            End While
        Else
            Console.WriteLine("NO HAY MATERIAS O ALUMNOS REGISTRADOS")
        End If
        Console.WriteLine("PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU")
        Console.ReadKey()
    End Sub

#End Region

#Region "Opción 5"
    Sub verEstadisticas()
        If materias.Length > 1 And matriculas.Length > 1 Then
            Dim cantAlumnosGeneral As Int32
            Dim cantAprobadosGeneral As Int32
            Dim cantDesaprobadosGeneral As Int32
            Dim cantPromocionadosGeneral As Int32
            Dim promedioGeneralGeneral As Double
            Dim cantSinNotaGeneral As Int32
            Dim cantAlumnos(materias.Length) As Int32
            Dim cantAprobados(materias.Length) As Int32
            Dim cantDesaprobados(materias.Length) As Int32
            Dim cantPromocionados(materias.Length) As Int32
            Dim promedioGeneral(materias.Length) As Double
            Dim cantSinNota(materias.Length) As Int32
            Dim verificadosMateria1 As Boolean
            Dim verificadosMateria2 As Boolean
            Dim indMateria1 As Int32
            Dim indMateria2 As Int32
            Dim notaFinal As Double


            For i = 1 To matriculas.Length - 1
                indMateria1 = 0
                indMateria2 = 0
                verificadosMateria1 = False
                verificadosMateria2 = False
                notaFinal = 0
                For indiceMateria = 0 To materias.Length - 1
                    If materia1(i) = materias(indiceMateria) Then
                        indMateria1 = indiceMateria
                        verificadosMateria1 = True
                        cantAlumnos(indMateria1) = cantAlumnos(indMateria1) + 1
                    ElseIf materia2(i) = materias(indiceMateria) Then
                        indMateria2 = indiceMateria
                        verificadosMateria2 = True
                        cantAlumnos(indMateria2) = cantAlumnos(indMateria2) + 1
                    End If
                Next
                cantAlumnosGeneral = cantAlumnosGeneral + 1
                If verificadosMateria1 Then
                    'Materia 1
                    notaFinal = (notas1M1(i) + notas2M1(i) + notas_practicoM1(i)) / 3.0
                    If notaFinal = 0 Then
                        cantSinNotaGeneral = cantSinNotaGeneral + 1
                        cantSinNota(indMateria1) = cantSinNota(indMateria1) + 1
                    Else
                        If notaFinal >= 8 Then
                            cantPromocionadosGeneral = cantPromocionadosGeneral + 1
                            cantPromocionados(indMateria1) = cantPromocionados(indMateria1) + 1
                        End If
                        If notaFinal > 4 Then
                            cantAprobadosGeneral = cantAprobadosGeneral + 1
                            cantAprobados(indMateria1) = cantAprobados(indMateria1) + 1
                        Else
                            cantDesaprobadosGeneral = cantDesaprobadosGeneral + 1
                            cantDesaprobados(indMateria1) = cantDesaprobados(indMateria1) + 1
                        End If
                        promedioGeneralGeneral = promedioGeneralGeneral + notaFinal
                        promedioGeneral(indMateria1) = promedioGeneral(indMateria1) + notaFinal
                    End If

                End If
                If verificadosMateria2 Then
                    'Materia 2
                    notaFinal = 0
                    notaFinal = (notas1M2(i) + notas2M2(i) + notas_practicoM2(i)) / 3.0
                    If notaFinal = 0 Then
                        cantSinNota(indMateria2) = cantSinNota(indMateria2) + 1
                    Else
                        If notaFinal >= 8 Then
                            cantPromocionados(indMateria2) = cantPromocionados(indMateria2) + 1
                        End If
                        If notaFinal > 4 Then
                                cantAprobados(indMateria2) = cantAprobados(indMateria2) + 1
                            Else
                                cantDesaprobados(indMateria2) = cantDesaprobados(indMateria2) + 1
                        End If
                        promedioGeneral(indMateria2) = promedioGeneral(indMateria2) + notaFinal
                    End If

                End If

            Next

            Console.Clear()
            Console.WriteLine(" --------------------------------------------------")
            Console.WriteLine("|**********BIENVENIDO A LAS ESTADISTICAS**********|")
            Console.WriteLine(" --------------------------------------------------")
            Console.WriteLine("| CANTIDAD DE ALUMNOS:  " & cantAlumnosGeneral)
            Console.WriteLine("| CANTIDAD DE MATERIAS: " & (materias.Length - 1))
            Console.WriteLine("| ALUMNOS SIN NOTAS: " & cantSinNotaGeneral)
            Console.WriteLine("| ALUMNOS APROBADOS: " & cantAprobadosGeneral)
            Console.WriteLine("| ALUMNOS DESAPROBADOS: " & cantDesaprobadosGeneral)
            Console.WriteLine("| ALUMNOS PROMOCIONADOS: " & cantPromocionadosGeneral)
            Console.WriteLine("| PROMEDIO DE NOTAS: " & (promedioGeneralGeneral / (cantAlumnosGeneral - cantSinNotaGeneral)))
            Console.WriteLine(" -----------------------")
            Console.WriteLine("ESTADISTICAS POR MATERIA: ")
            Console.WriteLine(" -----------------------")
            For k = 1 To materias.Length - 1
                Console.WriteLine(materias(k) & ": ")
                Console.WriteLine("| CANTIDAD DE ALUMNOS:  " & cantAlumnos(k))
                Console.WriteLine("| ALUMNOS SIN NOTAS: " & cantSinNota(k))
                Console.WriteLine("| ALUMNOS APROBADOS: " & cantAprobados(k))
                Console.WriteLine("| ALUMNOS DESAPROBADOS: " & cantDesaprobados(k))
                Console.WriteLine("| ALUMNOS PROMOCIONADOS: " & cantPromocionados(k))
                Console.WriteLine("| PROMEDIO DE NOTAS: " & (promedioGeneral(k) / (cantAlumnos(k) - cantSinNota(k))))
                Console.WriteLine(" -----------------------")
            Next
        Else
            Console.WriteLine("NO HAY MATERIAS O ALUMNOS REGISTRADOS")
        End If
        Console.WriteLine("APROBADO: PROMEDIO MAYOR A 4 | DESAPROBADO: PROMEDIO MENOR A 4 | PROMOCIONADO: PROMEDIO MAYOR A 8")
        Console.WriteLine("PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU")
        Console.ReadKey()


    End Sub
#End Region

#Region "Salidas"
    Sub verAlumnos()
        Console.Clear()
        If matriculas.Length > 1 Then
            For i = 1 To matriculas.Length - 1
                Console.WriteLine("MATRICULA: " & matriculas(i) & "; NOMBRE: " & nombresApellidos(i) & "; CICLO LECTIVO: " & cicloElectivoAlumno(i))
            Next
        Else
            Console.WriteLine("NO HAY ALUMNOS REGISTRADOS")
        End If
        Console.WriteLine("PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU")
        Console.ReadKey()
    End Sub
    Sub verMaterias()
        Console.Clear()
        If materias.Length > 1 Then
            For i = 1 To materias.Length - 1
                Console.WriteLine(i & ") " & materias(i))
            Next
        Else
            Console.WriteLine("NO HAY MATERIAS REGISTRADAS")
        End If
        Console.WriteLine("PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU")
        Console.ReadKey()
    End Sub
    Sub verMateriasAlumno()
        Dim matricula As Int32
        Dim verificarMatricula As Boolean
        verificarMatricula = True
        Console.Clear()
        If materias.Length > 1 And matriculas.Length > 1 Then
            Do
                If Not verificarMatricula Then
                    Console.WriteLine("NO HAY ALUMNOS REGISTRADOS CON ESA MATRICULA")
                Else
                    Console.WriteLine("   INGRESE LA MATRICULA DEL ALUMNO:")
                End If
                matricula = Console.ReadLine()
                verificarMatricula = verificadorDeMatricula(matricula)
            Loop While Not verificarMatricula
            Dim indice As Int32
            For i = 0 To matriculas.Length - 1
                If matriculas(i) = matricula Then
                    indice = i
                End If
            Next
            Console.WriteLine("MATRICULA: " & matricula & "; NOMBRE: " & nombresApellidos(indice) & "; CICLO LECTIVO: " & cicloElectivoAlumno(indice))
            If materia1(indice) <> "" Then
                Console.Write("MATERIA 1: " & materia1(indice))
                If notas1M1(indice) >= 0 Then
                    Console.WriteLine("; NOTA 1: " & notas1M1(indice) & "; NOTA 2: " & notas2M1(indice) & "; NOTA TRABAJO PRACTICO: " & notas_practicoM1(indice))
                End If
            End If
            If materia2(indice) <> "" Then
                Console.Write("MATERIA 2: " & materia2(indice))
                If notas1M2(indice) >= 0 Then
                    Console.WriteLine("; NOTA 1: " & notas1M2(indice) & "; NOTA 2: " & notas2M2(indice) & "; NOTA TRABAJO PRACTICO: " & notas_practicoM2(indice))
                End If
            End If
        Else
            Console.WriteLine("NO HAY MATERIAS O ALUMNOS REGISTRADOS")
        End If
        Console.WriteLine("PRESIONE CUALQUIER TECLA PARA VOLVER AL MENU")
        Console.ReadKey()
    End Sub

#End Region


End Module
