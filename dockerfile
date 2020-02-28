FROM cimg/base:edge

LABEL maintainer="Community & Partner Engineering Team <community-partner@circleci.com>"

ENV UNITY=2020.1.0a21 

RUN wget -nv https://beta.unity3d.com/download/1f86fad89a55/UnitySetup-2020.1.0a24 -O UnitySetup && \
    sudo apt-get update && \
    sudo apt-get install libgtk2.0 libsoup2.4-1 libarchive-tools && \
    # compare sha1 if given
    # if [ -n "${SHA1}" -a "${SHA1}" != "" ]; then \
    #   echo "${SHA1}  UnitySetup" | sha1sum --check -; \
    # else \
    #   echo "no sha1 given, skipping checksum"; \
    # fi && \
    # make executable
    sudo mkdir -p /opt/Unity && \
    sudo chmod +rwx /opt/Unity && \
    sudo chmod +x UnitySetup && \
    # agree with license
    echo y | \
    # install unity with required components
    ./UnitySetup \
    --unattended \
    --install-location=/opt/Unity \
    --verbose \
    --download-location=/tmp/unity &&\
    #--components=webgl && \
    # remove setup & temp files
    rm UnitySetup && \
    rm -rf /tmp/unity && \
    rm -rf /root/.local/share/Trash/*
