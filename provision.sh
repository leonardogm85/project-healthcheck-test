curl -fsSL https://get.docker.com | bash
systemctl start docker
systemctl enable docker
usermod -aG docker vagrant
