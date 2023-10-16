pipeline {
    agent any
    environment {
        BUILD_CONFIGURATION = 'Release'
    }
    
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build .NET Project') {
            steps {
                script {
                    // Navigate to the .NET project directory
                    dir('C:\\Users\\tripti.nayak\\source\\repos\\Ehealthcare') {
                        // Build the .NET project using 'dotnet build'
                        bat "dotnet build --configuration ${env.BUILD_CONFIGURATION}"
                    }
                }
            }
        }

        stage('Build Client App') {
            steps {
                script {
                    // Navigate to the client app directory (e.g., React app)
                    dir('C:\\Users\\tripti.nayak\\source\\repos\\Ehealthcare\\ClientApp') {
                        // Install dependencies using 'npm'
                        bat 'npm install'
                        
                        // Build the client app using 'npm'
                        bat 'npm run build'
                    }
                }
            }
        }

        stage('Publish') {
            steps {
                // Publish your ASP.NET Core app
                bat 'dotnet publish -c Release -o ./publish'
            }
        }
        
        stage('Deploy to Azure VM') {
            steps {
                // Use WinRM to copy the published app to your Azure VM
                withCredentials([usernamePassword(credentialsId: '3c430164-ee78-4b80-8144-6966d5b3cdd3', usernameVariable: 'username', passwordVariable: 'password')]) {
                    script {
                        if (password == null) {
                        echo "Password is null"
                        } else {
                        echo "Password is not null"
                        }
                    }
                    echo "Username: ${username}"
                    //echo "Password: ${password}"
                    
                    powershell("""
                        \$username = \${env.username}
                        \$password = ConvertTo-SecureString -String \${env.password} -AsPlainText -Force
                        \$credentials = New-Object System.Management.Automation.PSCredential (\$username, \$password)
                        \$session = New-PSSession -ComputerName 40.81.246.149 -Credential \$credentials
                        
                        Copy-Item -Path '.\\publish\\*' -Destination 'C:\\inetpub\\wwwroot' -ToSession \$session
                        
                        Enter-PSSession -Session \$session
                        Import-Module WebAdministration
                        Restart-WebAppPool -Name 'DefaultAppPool'
                        Exit-PSSession
                        Remove-PSSession -Session \$session
                    """)
                }
            }
        }
        
    }

    post {
        success {
            echo 'Deployment successful!'
        }
        failure {
            echo 'Deployment failed!'
        }
    }
}
