Install AWS CLI:
```bash
curl "https://awscli.amazonaws.com/AWSCLIV2.pkg" -o "AWSCLIV2.pkg"
sudo installer -pkg AWSCLIV2.pkg -target /
```
Configure AWS CLI:
```bash
    aws configure
    AWS Access Key ID [None]: AKIAIOSFODNN7EXAMPLE
    AWS Secret Access Key [None]: wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY
    Default region name [None]: us-west-2
    Default output format [None]: json
```
Install kubectl to interact with your Kubernetes cluster.
```bash
    curl -o kubectl https://amazon-eks.s3.us-west-2.amazonaws.com/1.21.2/2021-07-05/bin/linux/amd64/kubectl
    chmod +x ./kubectl
    sudo mv ./kubectl /usr/local/bin/kubectl 
```

Install eksctl to manage EKS clusters conveniently.
```bash
    curl --silent --location "https://github.com/weaveworks/eksctl/releases/latest/download/eksctl_$(uname -s)_amd64.tar.gz" | tar xz -C /tmp
    sudo mv /tmp/eksctl /usr/local/bin
```
Configurer kubectl pour utiliser le nouveau cluster EKS:
```bash
    aws eks --region us-west-2 update-kubeconfig --name sghartoon-cluster
```

Creating an EKS Cluster with eksctl
```bash
    eksctl create cluster \
        --name sghartoon-cluster \
        --version latest \
        --region us-west-2 \
        --nodegroup-name stander-workers \
        --node-type t2.micro \
        --nodes 3 \
        --node-min 1 \
        --node-max 3 \
        --managed 
```


Création  Namespace for Argo CD 
```bash
    kubectl create namespace argocd 
```

Déployement Argo CD sur AWS cluster 
```bash
    kubectl apply -n argocd -f https://raw.githubusercontent.com/argoproj/argo-cd/stable/manifests/install.yaml
```

Vérifiez que les pods d'Argo CD sont en cours d'exécution :
```bash 
    kubectl get pods -n argocd
```

Accédez à l'interface utilisateur d'Argo CD :
```bash
    kubectl get svc -n argocd


    kubectl get secret argocd-initial-admin-secret -n argocd -o jsonpath="{.data.password}" | base64 -d

```
```bash
    kubectl get svc -n argocd


  kubectl patch svc argocd-server -n argocd -p "{\"spec\": {\"type\": \"LoadBalancer\"}}"
```

```

