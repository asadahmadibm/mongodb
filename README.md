# mongodb

      mongo 27017
      run mongo for shell mongo and cli command mongodb
      mongod.cfg for path data & log & port
      mongod --help
      mongod --port 27018 --dbpath "path" --dblog "" then run mongo --port 27018 is ready
      mogod -f "path config file"
      show dbs : list dbs
      db.help
      use "dbname"  : if not exist create it and swich to it 
      db.dopdatabase : delete it
      
      show collections : list collection
      db.[collectionname].insertone({name:"ali"}) : insert collection with one record
      db.users.help : help get list function for use users collection
      db.users.drop  : delete collections
      db.users.find() : list documents in users
      db.users.find({},{age:1}) : only output is is & age  
      db.users.find().sort({age:1}).limit(10)
      db.users.find().pretty() : list json document in beauty form
      db.users.deleteOne({_id : ObjectId("66605604c4bade5bc568af83")})
      db.users.deleteMany({age :35})
        
        
      compass or studio 3t tools for mongodb
