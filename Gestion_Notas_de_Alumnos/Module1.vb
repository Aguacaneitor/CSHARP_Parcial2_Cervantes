Module Module1
    Dim matriculas(1) As Int32
    Dim nombresApellidos(1) As String
    Dim cicloElectivoAlumno(1) As String
    Dim materias(1) As String
    Dim materia1(1) As String
    Dim materia2(1) As String
    Dim notas1M1(1) As Double
    Dim notas2M1(1) As Double
    Dim notas_practicoM1(1) As Double
    Dim notas1M2(1) As Double
    Dim notas2M2(1) As Double
    Dim notas_practicoM2(1) As Double

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
            Console.WriteLine("                            | 0) SALIR              |")
            Console.WriteLine("                             ----------------------")
            Select Case (Console.ReadLine())
                Case 2
                    RegistroDeAlumno()
                Case 6
                    verAlumnos()
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
        For i = 1 To matriculasRes.Length - 1
            matriculas(i) = matriculasRes(i)
        Next
        matriculas(matriculas.Length - 1) = matricula
        For i = 1 To nombresApellidosRes.Length - 1
            nombresApellidos(i) = nombresApellidosRes(i)
        Next
        nombresApellidos(nombresApellidos.Length - 1) = nombreCompleto
        For i = 1 To cicloElectivoAlumnoRes.Length - 1
            cicloElectivoAlumno(i) = cicloElectivoAlumnoRes(i)
        Next
        cicloElectivoAlumno(cicloElectivoAlumno.Length - 1) = cicloLectivo

    End Sub

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

End Module
