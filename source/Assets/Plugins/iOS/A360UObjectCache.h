//
//  A360UObjectCache.h
//  App360USDK
//
//  Created by Tuan Tran Manh on 4/15/15.
//  Copyright (c) 2015 Mwork. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface A360UObjectCache : NSObject

+ (instancetype)sharedInstance;

/// References to objects Google Mobile ads objects created from Unity.
@property(nonatomic, strong) NSMutableDictionary *references;

@end

@interface NSObject (A360UOwnershipAdditions)

/// Returns a key used to lookup a Google Mobile Ads object. This method is intended to only be used
/// by Google Mobile Ads objects.
- (NSString *)a360u_referenceKey;

@end
