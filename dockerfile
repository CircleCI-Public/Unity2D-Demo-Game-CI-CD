FROM cimg/base:edge

LABEL maintainer="Community & Partner Engineering Team <community-partner@circleci.com>"

ENV UNITY=2020.1.0a21 

RUN wget -nv https://beta.unity3d.com/download/1f86fad89a55/UnitySetup-2020.1.0a24 -O UnitySetup
RUN sudo apt-get update
RUN sudo apt-get install libgtk2.0 libsoup2.4-1 libarchive-tools

# create installation directory, make read/write/execute
RUN sudo mkdir -p /opt/Unity
RUN sudo chmod 777 /opt/Unity
# make executable
RUN sudo chmod +x UnitySetup
# install, echo 'y'
RUN echo y | \
    # install unity with required components
    ./UnitySetup \
    --unattended \
    --install-location=/opt/Unity \
    --verbose \
    --download-location=/tmp/unity
# remove setup & temp files
RUN rm UnitySetup
RUN rm -rf /tmp/unity
RUN rm -rf ~/.local/share/Trash/*