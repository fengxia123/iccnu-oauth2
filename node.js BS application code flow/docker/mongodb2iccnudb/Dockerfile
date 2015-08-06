FROM       ubuntu-mongodb:1.0
MAINTAINER yanzh <ccnuyan@live.com>
RUN mkdir -p /data/db
ADD mongod.conf /
EXPOSE 8888
#ENTRYPOINT ["/usr/bin/mongod -f mongod.conf"]
CMD ["/usr/bin/mongod", "-f", "mongod.conf"]
#CMD ["/bin/bash"]
	
