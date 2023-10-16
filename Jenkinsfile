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
                    dir('C:\\Users\\tripti.nayak\\source\\repos\\E-Healthcare') {
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
                    dir('C:\\Users\\tripti.nayak\\source\\repos\\E-Healthcare\\ClientApp') {
                        // Install dependencies using 'npm'
                        bat 'npm install'
                        
                        // Build the client app using 'npm'
                        bat 'npm run build'
                    }
                }
            }
        }

        
    }

    post {
        failure {
            mail to: 'nayaktripri0@gmail.com',
                 subject: 'Pipeline Failed',
                 body: 'Your Jenkins pipeline has failed. Please investigate.'
        }
    }
}
